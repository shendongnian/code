    IDatabase database = null;
    
    while(database == null){
       try
       {
            database = databaseLoader.LoadDatabase();
       }
       catch(Exception e)
       {
            var connector = _userInteractor.GetDatabaseConnector();
            if(connector == null)
                    throw new ConfigException("Could not load the database specified in your config file.");
            databaseLoader = DatabaseLoaderFacade.GetDatabaseLoader(connector);
            //just in case??
            database = null;
       }
     }
