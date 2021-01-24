    var setting = ConfigurationManager.ConnectionStrings[DBName];
    if(setting != null) {
        string DbConnector = setting.ConnectionString;
        bool Connection1 = DbConnector.ToLower().StartWith("metadata");
        if (Connection1 == true)
        {
          System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder 
          efBuilder = new 
          System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(DbConnector);
          DbConnector = efBuilder.ProviderConnectionString;
        }
    }
    //...
