    static ObservableCollection<string> items = new ObservableCollection<string>() { "Item 1", "Item 2" };
    private void proxyListView_Loaded(object sender, RoutedEventArgs e)
    {
        proxyListView.ItemsSource = items;
    }
    
    private void item1_Click(object sender, RoutedEventArgs e)
    {
        items.RemoveAt(proxyListView.SelectedIndex);
    } 
     
