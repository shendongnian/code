    private void item1_Click(object sender, RoutedEventArgs e)
    {
        var ic = proxyListView.ItemsSource as IList<string>;
        ic.RemoveAt(proxyListView.SelectedIndex);
    }
