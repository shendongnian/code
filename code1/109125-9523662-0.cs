    List<string> columnNames = new List<string>();
    foreach (DataColumn col in table.Columns)
    {
        columnNames.Add(col.ColumnName);
    }
    columnNames.Sort();
    
    int i = 0;
    foreach (string name in columnNames)
    {
        table.Columns[name].SetOrdinal(i);
        i++;
    }
