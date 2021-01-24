    // No point of passing a bool if all you do is return it...
    private bool CheckDatabase(string databaseName)
    {
        // You know it's a string, use var
        var connString = "Server=localhost\\SQLEXPRESS;Integrated Security=SSPI;database=master";
        // Note: It's better to take the connection string from the config file.
        var cmdText = "select count(*) from master.dbo.sysdatabases where name=@database";
        using (var sqlConnection = new SqlConnection(connString))
        {
            using (var sqlCmd = new SqlCommand(cmdText, sqlConnection))
            {
                // Use parameters to protect against Sql Injection
                sqlCmd.Parameters.Add("@database", System.Data.SqlDbType.NVarChar).Value = databaseName;
                    
                // Open the connection as late as possible
                sqlConnection.Open();
                // count(*) will always return an int, so it's safe to use Convert.ToInt32
                return Convert.ToInt32( sqlCmd.ExecuteScalar()) == 1;
            }
        }
        
    }
