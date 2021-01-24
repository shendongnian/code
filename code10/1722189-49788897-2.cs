    private DataTable _dataTable;
    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
        var selectedItem = dataGrid.SelectedItem as DataRowView;
        if (selectedItem != null)
        {
            _dataTable.Rows.Remove(selectedItem.Row); 
            _dataTable.AcceptChanges();
        }
    }
