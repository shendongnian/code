    private override void ConfigureDatabase(IServiceCollection services)
    {
        var databaseName = Guid.NewGuid().ToString();
        services.AddDbContext<MyContext>(o =>
            o.UseInMemoryDatabase(databaseName));
    }
