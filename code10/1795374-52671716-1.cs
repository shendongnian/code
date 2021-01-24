    public DataTable RemoveDuplicateRows(DataTable dt, string colName)
    {
        var uniqueRows = new Dictionary<string, DataRow>();
        foreach (DataRow thisRrow in dt.Rows)
        {
            if (uniqueRows.ContainsKey(colName))
            {
                uniqueRows[colName] = thisRrow;
            }
            else
            {
                uniqueRows.Add(colName, thisRrow);
            }
        }
        DataTable copy = dt.Copy();
        copy.Rows.Clear();
        foreach (var thisRow in uniqueRows)
        {
            copy.Rows.Add(thisRow);
        }
        //Datatable which contains unique records will be return as output.
        return copy;
    }
