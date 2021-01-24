    DbProviderFactory factory = DbProviderFactories.GetFactory("Npgsql");
    using(DbConnection con = factory.CreateConnection()) 
    {
          con.ConnectionString = ConfigurationManager.AppSettings[connectionName];
          con.Open();  
          // Connection is open, notify user
          DbCommand cmd = connection.CreateCommand();
          cmd.CommandText = query; 
    
          // Query execution is going to start, add code to inform user
          cmd.ExecuteXXX();
          // Query execution is done, add code to inform user
    }
    // the connection is closed - notify user
