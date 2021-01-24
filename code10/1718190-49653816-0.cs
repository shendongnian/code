    private void PendingDetailsDataGrid_GotFocus(object sender, RoutedEventArgs e)
    {
        if (e.OriginalSource.GetType() == typeof(System.Windows.Controls.DataGridCell))
        {
            DataGrid grd = (DataGrid)sender;
            grd.BeginEdit(e);
        }
    }
