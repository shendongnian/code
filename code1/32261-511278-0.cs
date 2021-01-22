    DbProviderFactory factory = GiveMeSomeFactory();
    IDbCommand command = factory.CreateCommand();
    IDataReader r = command.ExecuteReader();
    //and create more objects
    IDataAdapter adapter = factory.CreateDataAdapter();
    IDbConnection conn = factory.CreateConnection();
