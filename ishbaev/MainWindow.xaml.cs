using System;
using System.Linq;
using System.Windows;

namespace ishbaev
{
    public partial class MainWindow : Window
    {
        // Подключение к вашей базе данных
        ishbaevEntities db = new ishbaevEntities();

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        // Загрузка данных во все таблицы
        private void LoadData()
        {
            try
            {
                dgProducts.ItemsSource = db.Товары.ToList();
                dgArrivals.ItemsSource = db.Приёмка.ToList();
                dgUnloading.ItemsSource = db.Разгрузка.ToList();
                dgAccounting.ItemsSource = db.Бухгалтерия.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка базы данных: " + ex.Message);
            }
        }

        // Логика кнопки Обновить (исправляет CS1061)
        private void RefreshAll_Click(object sender, RoutedEventArgs e)
        {
            db = new ishbaevEntities();
            LoadData();
        }

        // Логика кнопки Добавить (исправляет CS1061)
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Окно добавления товара в разработке");
        }

        // Логика кнопки Удалить (исправляет CS1061)
        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (dgProducts.SelectedItem is Товары selected)
            {
                db.Товары.Remove(selected);
                db.SaveChanges();
                LoadData();
            }
        }
    }
}