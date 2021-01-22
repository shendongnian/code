    public static Hashtable convertDataRowToHashTable(DataRow dr)
    {
        if (dr == null)
        {
            return null;
        }
        Hashtable ret = new Hashtable(dr.Table.Columns.Count);
        for (int iColNr = 0; iColNr < dr.Table.Columns.Count; iColNr++)
        {
            ret[dr.Table.Columns[iColNr].ColumnName] = dr[iColNr];
        }
        return ret;
    }
