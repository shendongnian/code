    var builder = new SqlConnectionStringBuilder
    {
        DataSource = @"IP_ADDRESS\INSTANCE",
        InitialCatalog = "DbName",
        UserID = "MyUserId",
        Password = "MyPassword"
    };
    var connectionString = builder.ConnectionString;
    // Use connection string
    optionsBuilder.UseSqlServer(connectionString );
