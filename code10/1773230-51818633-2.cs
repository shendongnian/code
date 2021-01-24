    private void PreviousClick(object sender, RoutedEventArgs e)
    {
        if (TableDataGrid.SelectedIndex > 0)
            TableDataGrid.SelectedIndex--;
    }
    private void NextClick(object sender, RoutedEventArgs e)
    {
        if (TableDataGrid.SelectedIndex < TableDataGrid.Items.Count - 1)
            TableDataGrid.SelectedIndex++;
    }
