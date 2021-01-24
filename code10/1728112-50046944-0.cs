    dataGrid.AutoGenerateColumns = true;
    dataGrid.ItemsSource = new List<Item> { new Item() { Name = "some very long name..." } };
    dataGrid.Loaded += (s, e) => 
    {
        dataGrid.Dispatcher.Invoke(new Action(() =>
        {
            MessageBox.Show(dataGrid.Columns[0].ActualWidth.ToString());
        }), System.Windows.Threading.DispatcherPriority.Input);
    };
