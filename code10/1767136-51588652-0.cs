    //get the information out of the configuration file.
    var connectionStringSettings = 
           ConfigurationManager.ConnectionStrings["Db"];
    
    //get the proper factory and mandatory to have SQL Provide name in the connection string
    DbProviderFactory factory = 
      DbProviderFactories.GetFactory(connectionStringSettings.ProviderName);
    
    //create a command of the proper type.
    DbConnection conn = factory.CreateConnection();
    //set the connection string
    conn.ConnectionString = connectionStringSettings.ConnectionString;
    
    //open the connection
    conn.Open();
    
    Repository = new Repository();
    return Repository.Load(() => conn);
