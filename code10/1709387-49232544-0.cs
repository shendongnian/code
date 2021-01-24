    private static void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        if (e.Column.GetType() == typeof(DataGridTemplateColumn))
        {
            var popup = GetVisualChild<Popup>(e.EditingElement);
            if (popup != null && popup.IsOpen)
            {
                e.Cancel = true;
            }
        }   
    }
