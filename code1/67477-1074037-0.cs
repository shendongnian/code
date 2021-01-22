    private string GetConnectionString(String connectionName)
    {
       //Get the connection string info from web.config
       ConnectionStringSettings cs= ConfigurationManager.ConnectionStrings[connectionName];
    
       //documented to return null if it couldn't be found
       if (cs == null)
           throw new ArgumentException("Could not find connection string \""+connectionName+"\"");
       return cs;
    }
    private DbProviderFactory GetFactory(String ProviderName)
    {
       //Get the factory for the given provider (e.g. "System.Data.SqlClient")
       DbProviderFactory factory = DbProviderFactories.GetFactory(ProviderName);
    
       //Undefined behaviour if GetFactory couldn't find a provider.
       //Defensive test for null factory anyway
       if (factory == null)
          throw new Exception("Could not obtain factory for provider \""+ProviderName+"\"");
       return factory;
    }
    public DbConnection GetConnection(String connectionName)
    {
       //Get the connection string info from web.config
       ConnectionStringSettings cs = GetConnectionString(connectionName);
    
       //Get the factory for the given provider (e.g. "System.Data.SqlClient")
       DbProviderFactory factory = GetFactory(cs.ProviderName);
    
     
       //Have the factory give us the right connection object
       DbConnection conn = factory.CreateConnection();
    
       //Undefined behaviour if CreateConnection failed
       //Defensive test for null connection anyway
       if (conn == null)
          throw new Exception("Could not obtain connection from factory");
    
       //Knowing the connection string, open the connection
       conn.ConnectionString = cs.ConnectionString;
       conn.Open()
    
       return conn;
    }
