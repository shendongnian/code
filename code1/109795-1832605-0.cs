    foreach (var key in list[0].Keys) // assume the first defines everything
    {
        object[] rowData = new object[list.Count + 1];
        rowData[0] = key;
        for(int i = 0 ; i < list.Count ; i++) {
            rowData[i+1] = list[i][key];
        }
        table.Rows.Add(rowData);
    }
