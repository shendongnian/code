    foreach (DataGridCellInfo cellInfo in dataGrid.SelectedCells)
    {
        DataGridCell gridCell = TryToFindGridCell(dataGrid, cellInfo);
        if (gridCell != null && gridCell.Content is TextBlock)
            Console.WriteLine(((TextBlock)gridCell.Content).Text);
    }
