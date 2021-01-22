    System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
    
    builder.ConnectionString = connectionString;
    
    string server = builder.DataSource;
    string database = builder.InitialCatalog;
