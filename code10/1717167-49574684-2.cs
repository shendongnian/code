    private void ItemButtonClick(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        var item = button.DataContext as DataEntity;
        MessageBox.Show("Clicked " + item.Name);
    }
