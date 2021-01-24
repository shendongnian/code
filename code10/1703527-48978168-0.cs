        var services = new ServiceCollection();
        services.AddEntityFramework()
            .AddInMemoryDatabase()
            .AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase());
        serviceProvider = services.BuildServiceProvider();
