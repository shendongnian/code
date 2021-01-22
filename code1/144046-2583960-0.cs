    private void CopyColumn(DataTable srcTable, DataTable dstTable, string srcColName, string dstColName)
    {
        foreach (DataRow row in srcTable.Rows )
        {
            DataRow newRow = dstTable.NewRow();
            newRow[dstColName] = row[srcColName];
            dstTable.Rows.Add(newRow);
        }
    }
