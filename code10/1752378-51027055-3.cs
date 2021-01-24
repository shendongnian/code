    public static StoreContext ConfigureStoreContext(IServiceCollection services)
    {
        services.AddDbContext<StoreContext>(c =>
            c.UseInMemoryDatabase(Guid.NewGuid().ToString()).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        var serviceProvider = services.BuildServiceProvider();
        var storeContext = serviceProvider.GetRequiredService<StoreContext>();
        var s1 = new Store { Title = "John's store", Address = "NY", Description = "Electronics best deals", SellerId = "john@mail.com" };
        var s2 = new Store { Title = "Jennifer's store", Address = "Sydney", Description = "Fashion", SellerId = "jennifer@mail.com" }
        storeContext .Stores.Add(s1);
        storeContext .Stores.Add(s2);
        storeContext .Entry<Store>(s1).State = EntityState.Detached;
        storeContext .Entry<Store>(s2).State = EntityState.Detached;
        storeContext .SaveChanges();
        return storeContext ;
    }
