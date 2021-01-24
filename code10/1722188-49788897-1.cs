    private DataTable _dataTable;
    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
        var selectedItem = ((DataRowView)dataGrid.SelectedItem)?.Row;
        if (selectedItem != null)
        {
            _dataTable.Rows.Remove(selectedItem); 
            _dataTable.AcceptChanges();
        }
    }
