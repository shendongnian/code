    public static string ConnectionString
    {
        get
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "PROD")
            {
                return Environment.GetEnvironmentVariable("CONNECTION_STRING");
            }
            else
            {
                return @"Server=.;Database=database;Trusted_Connection=True;ConnectRetryCount=0";
            }
        }
    }
    public UsersDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<UsersDbContext>();
        optionsBuilder.UseSqlServer(ConnectionString);
        return new UsersDbContext(optionsBuilder.Options);
    }
