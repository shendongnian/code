    foreach (object item in this.DataGrid1.Items)
    {
        Dispatcher.BeginInvoke(new Action<object>(RemoveRowHighlights), DispatcherPriority.ApplicationIdle, item);
    }
    ...
    private void RemoveRowHighlights(object item)
    {
        Xceed.Wpf.DataGrid.DataRow row = this.DataGrid1.GetContainerFromItem(item) as Xceed.Wpf.DataGrid.DataRow;
        if (row != null) foreach (Xceed.Wpf.DataGrid.DataCell c in row.Cells)
        {
            if (c != null) c.Background = row.Background;
        }
    }
