    private void DataGridControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
        if (sender is DataGridControl dg)
        {
            dg.SelectedItem = null;
        }
    }
