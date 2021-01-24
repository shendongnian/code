    private void item1_Click(object sender, RoutedEventArgs e)
    {
        GlobalVars.URLLinks.RemoveAt(proxyListView.SelectedIndex);
        proxyListView.ItemsSource = GlobalVars.URLLinks;
    }
