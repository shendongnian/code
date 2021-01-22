    void CopyTable(DataTable table, string connectionStringB)
    {
        var connectionB = new OleDbConnection(connectionStringB);
        foreach(DataRow row in table.Rows)
        {
            InsertRow(row, table.Columns, "Staff", connectionB);
        }
    }
    
    public static void InsertRow(DataRow row, DataColumnCollection columns, string table, OleDbConnection connection)
    {
        var columnNames = new List<string>();
        var values = new List<string>();
    
        for(int i =0;i<columns.Count; i++)
        {
            columnNames.Add("[" + columns[i].ColumnName + "]");
            values.Add("'" + row[i].ToString().Replace("'", "''") + "'");
        }
    
        string sql = string.Format("INSERT INTO {0} ({1}) VALUES ({2})",
                table,
                string.Join(", ", columnNames.ToArray()),
                string.Join(", ", values.ToArray())
            );
        
        ExecuteNonQuery(sql, connection);
    }
    
    public static void ExecuteNonQuery(string sql, OleDbConnection conn)
    {
        if (conn == null)
            throw new ArgumentNullException("conn");
    
        ConnectionState prevState = ConnectionState.Closed;
        var command = new OleDbCommand(sql, conn);
        try
        {
            prevState = conn.State;
            if (prevState != ConnectionState.Open)
                conn.Open();
    
            command.ExecuteNonQuery();
        }
        finally
        {
            if (conn.State != ConnectionState.Closed
                && prevState != ConnectionState.Open)
                conn.Close();
        }
    }
