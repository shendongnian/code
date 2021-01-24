    // This is the list where the values will be stored. Now it's empty.
    List<string> values = new List<string>();
    // Whit this 'foreach' we iterate over 'gridData' selected cells.
    foreach (DataGridCellInfo x in gridData.SelectedCells)
    {
        // With this line we're storing the value of the cells as strings
        // in the previous list.
        values.Add(x.Item.ToString());
    }
