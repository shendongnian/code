    IDatabase loadedDatabase = null;
    
    // first try
    try
    {
        loadedDatabase = databaseLoader.LoadDatabase();
    }
    catch(Exception e) { }  // THIS IS BAD DON'T DO THIS
    
    // second try
    if(loadedDatabase == null) 
    {
        var connector = _userInteractor.GetDatabaseConnector();
        if(connector == null)
            throw new ConfigException("Could not load the database specified in your config file.");
        databaseLoader = DatabaseLoaderFacade.GetDatabaseLoader(connector);
        loadedDatabase = databaseLoader.LoadDatabase()
    }
