    public static Hashtable Fn_ConvertDataTableToHashTable(DataTable dtTable, int iRow)
    {
        Hashtable hshTable = new Hashtable();
        if (CommonUtil.Fn_CheckDatatableHasValue(dtTable))
            foreach (DataColumn column in dtTable.Columns)
                hshTable.Add(column.ColumnName, dtTable.Rows[iRow][column.ColumnName].ToString());
        return hshTable;
    }
