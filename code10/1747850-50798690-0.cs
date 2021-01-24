    DataView dv = targetDataGrid.ItemsSource as DataView;
    if (dv != null)
    {
        foreach (var selectedItem in selectGrid.SelectedItems.OfType<DataRowView>())
        {
            dv.Table.Rows.Add(selectedItem.Row.ItemArray);
        }
    }
