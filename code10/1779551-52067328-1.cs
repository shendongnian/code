    // we keep the Redis cache as the default
    services.AddDistributedRedisCache();
    // no call to `AddSqlServerCache` as we don’t want to overwrite the `IDistributedCache`
    // registration; instead, register (and configure) the SqlServerCache directly
    services.AddSingleton<SqlServerCache>();
    services.Configure<SqlServerCacheOptions>(options =>
    {
        // here goes the configuration that would normally be done in the
        // configure action passed to `AddSqlServerCache`
        options.ConnectionString = Configuration.GetConnectionString("DistributedCache");
    });
    // add session, but overwrite the `ISessionStore` afterwards
    services.AddSession();
    services.AddTransient<ISessionStore, SqlServerCacheSessionStore>();
