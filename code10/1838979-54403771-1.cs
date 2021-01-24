    public CobraLettersRepository(ProjectConfiguration configuration)
    {
        if(configuration == null){
            throw new ArgumentNullException(configuration);
        }
        _connString = configuration.ConnectionString;
    
        dbConnection = new SqlConnection(_connString);
        dbConnection.Open();
    }
