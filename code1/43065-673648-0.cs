    public static void RemoveColumns(DataTable dt, params DataColumn[] dc)
    {
        foreach (DataColumn c in dc)
        {
            dt.Columns.Remove(c);
        }
    }
    RemoveColumns(ds.Tables[0], ds.Tables[0].Columns[1], ds.Tables[0].Columns[2]);
