    private void dataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        DataGrid dataGrid = (DataGrid)sender;
        DataGridTextColumn column = e.Column as DataGridTextColumn;
        if (column != null)
        {
            column.ElementStyle = dataGrid.Resources["ElementStyle"] as Style;
        }
    }
