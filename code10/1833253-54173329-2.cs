    private void DataGrid_OnLoaded(object sender, RoutedEventArgs e)
    {
        if (sender is DataGrid dataGrid)
        {
            if (DataContext is HardwareViewModel)
            {
                dataGrid.Columns.Add(Resources["IdColumn"] as DataGridColumn);
                dataGrid.Columns.Add(Resources["TypeColumn"] as DataGridColumn);
                // More columns added here
            }
            else if (DataContext is AnotherHardwareViewModel)
            {
                dataGrid.Columns.Add(Resources["IdColumn"] as DataGridColumn);
                dataGrid.Columns.Add(Resources["LabelColumn"] as DataGridColumn);
                dataGrid.Columns.Add(Resources["LastModifiedColumn"] as DataGridColumn);
                // More columns added here
            }
        }
    }
