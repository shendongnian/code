    private void InitializeConnection()
    {
    	var builder = new MySqlConnectionStringBuilder
    	{
    		Server = "localhost",
    		Database = "table",
    		UserID = "root",
    		Password = "",
    	}
    	
    	string connectionString = builder.ConnectionString;
    	ObjConnection = new MySqlConnection(connectionString);
        // OR: ObjConnection = new MySqlConnection(builder.ConnectionString);
    }
