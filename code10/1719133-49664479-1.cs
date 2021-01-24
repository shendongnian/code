        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            var items = new ObservableCollection<Product>();
            for (int i = 0; i < 9; i++)
            {
                items.Add(new Product($"item {i}"));
            }
            this.Items.ItemsSource = items;
        }
