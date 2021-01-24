    foreach (var item in grid.Items)
    {
        var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
        if (row == null)
            continue;
        foreach (var column in grid.Columns)
        {
            if (!(column.GetCellContent(row) is TextBlock))
                continue;
            var cell = column.GetCellContent(row) as TextBlock;
            var text = cell?.Text; // this is the cell value
        }
    }
