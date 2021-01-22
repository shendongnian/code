    void CopyTable(DataTable table, string connectionStringB)
    {
        var connectionB = new OleDbConnection(connectionStringB);
        foreach(DataRow row in table.Rows)
        {
            InsertRow(row, table.Columns, table.TableName, connectionB);
        }
    }
    
    public static void InsertRow(DataRow row, DataColumnCollection columns, string table, OleDbConnection connection)
    {
        var columnNames = new List<string>();
        var values = new List<string>();
        // generate the column and value names from the datacolumns    
        for(int i =0;i<columns.Count; i++)
        {
            columnNames.Add("[" + columns[i].ColumnName + "]");
            // datatype mismatch should be fixed by this function
            values.Add(MakeValueDbReady(row[i], columns[i].DataType));
        }
    
        // create the sql
        string sql = string.Format("INSERT INTO {0} ({1}) VALUES ({2})",
                table,
                string.Join(", ", columnNames.ToArray()),
                string.Join(", ", values.ToArray())
            );
        
        // debug the accuracy of the sql here and even copy into 
        // a new Query in Access to test
        ExecuteNonQuery(sql, connection);
    }
    // as the name says we are going to check the datatype and format the value
    // in the sql string based on the type that the database is expecting
    public string MakeValueDbReady(object value, Type dataType)
    {
        if (value == null)
            return null;
        if (dataType == typeof(string))
        {
            return "'" + value.ToString().Replace("'", "''") + "'"
        }
        else if (dataType == typeof(DateTime))
        {
            return "#" + ((DateTime)value).ToString + "#"
        }
        else if (dataType == typeof(bool))
        {
            return ((bool)value) ? "1" : "0";
        }
        return value.ToString();
    }
    
    public static void ExecuteNonQuery(string sql, OleDbConnection conn)
    {
        if (conn == null)
            throw new ArgumentNullException("conn");
    
        ConnectionState prevState = ConnectionState.Closed;
        var command = new OleDbCommand(sql, conn);
        try
        {
            // the reason we are checking the prev state is for performance reasons
            // later you might want to open the connection once for the a batch
            // of say 500 rows  or even wrap your connection in a transaction.
            // we don't want to open and close 500 connections
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
