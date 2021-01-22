    public static void InsertAfter(this DataColumnCollection columns, 
                                  DataColumn currentColumn, DataColumn newColumn)
    {
        if (!columns.Contains(currentColumn.ColumnName))
           throw new ArgumentException(/** snip **/);
        columns.Add(newColumn);
        //add the new column after the current one
        columns[newColumn.ColumnName].SetOrdinal(currentColumn.Ordinal + 1); 
    }
