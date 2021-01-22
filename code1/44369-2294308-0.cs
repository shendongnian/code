    public static string GetSqlCeConnectionString(string fileName)
    {
        var csBuilder = new EntityConnectionStringBuilder();
    
        csBuilder.Provider = "System.Data.SqlServerCe.3.5";
        csBuilder.ProviderConnectionString = string.Format("Data Source={0};", fileName);
    
        csBuilder.Metadata = string.Format("res://{0}/YourEdmxFileName.csdl|res://{0}/YourEdmxFileName.ssdl|res://{0}/YourEdmxFileName.msl", 
            typeof(YourObjectContextType).Assembly.FullName);
    
        return csBuilder.ToString();
    }
    
    public static string GetSqlConnectionString(string serverName, string databaseName)
    {
        SqlConnectionStringBuilder providerCs = new SqlConnectionStringBuilder();
    
        providerCs.DataSource = serverName;
        providerCs.InitialCatalog = databaseName;
        providerCs.IntegratedSecurity = true;
    
        var csBuilder = new EntityConnectionStringBuilder();
    
        csBuilder.Provider = "System.Data.SqlClient";
        csBuilder.ProviderConnectionString = providerCs.ToString();
    
        csBuilder.Metadata = string.Format("res://{0}/YourEdmxFileName.csdl|res://{0}/YourEdmxFileName.ssdl|res://{0}/YourEdmxFileName.msl",
            typeof(YourObjectContextType).Assembly.FullName);
    
        return csBuilder.ToString();
    }
