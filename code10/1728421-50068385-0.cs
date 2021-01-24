    private void DataGrid_CopyingRowClipboardContent(object sender, DataGridRowClipboardEventArgs e)
    {
        //because we need to use displayindex, we need to check how many collapsed columns there are before our column, and adjust our display index accordingly
        int invisibleCols = 0;
        foreach(DataGridColumn col in VwrGrid.Columns)
        {
            if (col.Visibility == Visibility.Collapsed)
                invisibleCols++;
            if (col.Header.ToString() == VwrGrid.CurrentCell.Column.Header.ToString()) break;
        }
        try
        {
            var currentCell = e.ClipboardRowContent[VwrGrid.CurrentCell.Column.DisplayIndex - invisibleCols];
            e.ClipboardRowContent.Clear();
            e.ClipboardRowContent.Add(currentCell);
        }
        catch
        {
        }
    }
