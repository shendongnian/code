    public System.Collections.Generic.Dictionary<string, string> GetAllTables(System.Data.SqlClient.SqlConnection _connection)
    {
        if (_connection.State == System.Data.ConnectionState.Closed)
            _connection.Open();
        System.Data.DataTable dt = _connection.GetSchema("Tables");
        System.Collections.Generic.Dictionary<string, string> tables = new System.Collections.Generic.Dictionary<string, string>();
        foreach (System.Data.DataRow row in dt.Rows)
        {
            if (row[1].ToString().Equals("BASE TABLE", StringComparison.OrdinalIgnoreCase)) //ignore views
            {
                string tableName = row[2].ToString();
                string schema = row[1].ToString();
                tables.Add(tableName, schema);
            }
        }
        _connection.Close();
        return tables;
    }
