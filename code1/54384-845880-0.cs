    foreach(DataColumn col in drs[0].Table.Columns)
    {
        dt.Columns.Add(col.ColumnName, col.DataType, col.Expression);
    }
    
