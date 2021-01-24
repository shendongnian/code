    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connString = "Server=(localdb)\\mssqllocaldb;Database=HavenServer;ConnectRetryCount=0;Trusted_Connection=True;MultipleActiveResultSets=true\"";
            optionsBuilder
                .UseLoggerFactory(MyConsoleLoggerFactory)
                .EnableSensitiveDataLogging(false)
                .UseSqlServer(connString, options => options.MaxBatchSize(150));
        }
        base.OnConfiguring(optionsBuilder);
    }
