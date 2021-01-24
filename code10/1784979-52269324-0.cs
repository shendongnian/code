    DataGridRow row = mtoDG.ItemContainerGenerator.ContainerFromIndex(i) as DataGridRow;
    if (row != null)
    {
        if (mtoDG.Columns[colIndex].GetCellContent(row) is TextBlock cellContent && cellContent.Text.Equals(selection))
        {
            object item = mtoDG.Items[i];
            mtoDG.SelectedItems.Add(item);
        }
    }
