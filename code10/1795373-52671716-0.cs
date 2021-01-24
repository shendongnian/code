    public DataTable RemoveDuplicateRows(DataTable dt, string colName)
    {
        var duplicateList = new ArrayList();
        var uniqueRows = new Dictionary<string, DataRow>();
        foreach (DataRow thisRrow in dt.Rows)
        {
            if (uniqueRows.ContainsKey(colName))
            {
                uniqueRows[colName] = thisRrow;
                duplicateList.Add(thisRrow);
            }
            else
            {
                uniqueRows.Add(colName, thisRrow);
            }
        }
        //Removing a list of duplicate items from datatable.
        foreach (DataRow dRow in duplicateList)
            dt.Rows.Remove(dRow);
        //Datatable which contains unique records will be return as output.
        return dt;
    }
