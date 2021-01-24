    private void PreviousClick(object sender, RoutedEventArgs e)
    {
        DataRowView rowSelected = TableDataGrid.SelectedItem as DataRowView;
        if (rowSelected == null)
            return;
        int idx = GetDataRowViewIndex(rowSelected);
        if (idx > 0)
            TableDataGrid.SelectedItem = rowSelected.DataView[idx - 1];
    }
    private void NextClick(object sender, RoutedEventArgs e)
    {
        DataRowView rowSelected = TableDataGrid.SelectedItem as DataRowView;
        if (rowSelected == null)
            return;
        int idx = GetDataRowViewIndex(rowSelected);
        if (idx < rowSelected.DataView.Count - 1)
            TableDataGrid.SelectedItem = rowSelected.DataView[idx + 1];
    }
    int GetDataRowViewIndex(DataRowView row)
    {
        for (int i = 0; i < row.DataView.Count; i++)
            if (row.DataView[i] == row)
                return i;
        return -1;
    }
