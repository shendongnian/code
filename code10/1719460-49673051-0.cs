    var dt = new DataTable();
    // create columns and headers
    int columnCount = headers.Count;
    for (int i = 0; i < columnCount; i++)
        dt.Columns.Add(headers[i]);
    
    // copy rows data
    for (int i = 0; i < tableValues.Count; i++)
        dt.Rows.Add(tableValues[i].Take(columnCount).ToArray());
    // display in a DataGrid
    dataGrid.ItemsSource = dt.DefaultView;
