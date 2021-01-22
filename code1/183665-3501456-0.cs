    // Some values
    var someValues = Enumerable.Range(1, 10);
    // Fill up the first column
    foreach (var item in someValues)
    {
        listView.Items.Add("0." + item);
    }
    // Run for each column in the listView (the first is already filled up)
    foreach (ColumnHeader column in listView.Columns.Cast<ColumnHeader>().Skip(1))
    {
        // Get the value and the index for which row the value should be
        foreach (var item in someValues.Select((Value, Index) => new { Value, Index }))
        {
            // Add the value to the given row, thous leading to be added as new column
            listView.Items[item.Index].SubItems.Add(column.Index + "." + item.Value);
        }
    }
