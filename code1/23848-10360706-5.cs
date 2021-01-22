    public List<string> ExecuteColumnNamesReader(string command, List<SqlParameter> Params)
    {
        List<string> ColumnNames = new List<string>();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand sqlComm = new SqlCommand(command, connection);
        foreach (SqlParameter p in Params) { sqlComm.Parameters.Add(p); }
        da.SelectCommand = sqlComm;
        DataTable dt = new DataTable();
        da.Fill(dt);
        DataRow row = dt.Rows[0];
        for (int ordinal = 0; ordinal < dt.Columns.Count; ordinal++)
        {
            string column_name = dt.Columns[ordinal].ColumnName;
            ColumnNames.Add(column_name);
        }
        return ColumnNames; // you can then call .Contains("name") on the returned collection
    }
