    IDatabase database = null;
    
    bool bSuccess = false;
    int iTries = 0
    while (!bSuccess) // or while (database == null)
    {
        try
        {
            iTries++;
            database = databaseLoader.LoadDatabase();
            bSuccess = true;
        }
        catch(DatabaseLoaderException e)
        {
            //Avoid an endless loop
            if (iTries > 10)
                 throw e;
    
            var connector = _userInteractor.GetDatabaseConnector();
            if(connector == null)
                 throw new ConfigException("Could not load the database specified in your config file.");
            databaseLoader = DatabaseLoaderFacade.GetDatabaseLoader(connector);
        }
    }
