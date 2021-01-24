    public TestBase()
    {
        services = new ServiceCollection();
        storeContext = StoreContextMock.ConfigureStoreContext(services, output);
        serviceProvider = services.BuildServiceProvider();
    }
    public static StoreContext ConfigureStoreContext(IServiceCollection services)
    {
        services.AddDbContext<StoreContext>(c =>
            c.UseInMemoryDatabase(Guid.NewGuid().ToString()).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        var serviceProvider = services.BuildServiceProvider();
        var storeContext = serviceProvider.GetRequiredService<StoreContext>();
        storeContext .Stores.Add(new Store { Title = "John's store", Address = "NY", Description = "Electronics best deals", SellerId = "john@mail.com" });
        storeContext .Stores.Add(new Store { Title = "Jennifer's store", Address = "Sydney", Description = "Fashion", SellerId = "jennifer@mail.com" });
        storeContext .SaveChanges();
        return storeContext ;
    }
