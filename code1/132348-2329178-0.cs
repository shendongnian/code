    foreach (ColumnTypeStrinRep columnInput in rowInput)
    {
        Debug.Assert(row.Table.Columns.Contains(columnInput.columnName));
        Debug.Assert(row.Table.Columns[columnInput.columnName].DataType == columnInput.type);
        ...
        row[columnInput.columnName] = Convert.ChangeType(columnInput.stringRep, columnInput.type);
    }
