    private void DataGrid_GotFocus(object sender, RoutedEventArgs e)
    {
        // Lookup for the source to be DataGridCell
        if (e.OriginalSource.GetType() == typeof(DataGridCell))
        {
            // Starts the Edit on the row;
            DataGrid grd = (DataGrid)sender;
            grd.BeginEdit(e);
        }
    }
