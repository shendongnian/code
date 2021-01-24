    public static DataTable SortTable(DataTable table)
    {
        var comparer = new PrecedenceComparer<string>(new string[] { "foundation", "column", "beam" });
        // sort the rows of the original table
        var orderedRows = table.Rows.Cast<DataRow>()
            .OrderBy(row => (string)row["type"], comparer)
            .ThenBy(row => (int)row["vol"])   // secondary sort (delete this line if there isn't one)
            ;
        // copy the sorted data to a new table
        DataTable newTable = new DataTable();
        foreach (DataColumn col in table.Columns)
        {
            newTable.Columns.Add(col.ColumnName, col.DataType);
        }
        foreach (DataRow row in orderedRows)
        {
            DataRow newRow = newTable.NewRow();
            for (int i = 0; i < table.Columns.Count; i++)
            {
                newRow[i] = row[i];
            }
            newTable.Rows.Add(newRow);
        }
        return newTable;
    }
