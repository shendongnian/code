    var services = new ServiceCollection();
    services.AddTransient<Main>(); // With constructor of public Main(Services service)
    
    //....
    services.AddDbContext<DbContext>(o => o.UseSqlServer(defaultConn));
    services.AddSingleton<Services>();
    
    var serviceProvider = services.BuildServiceProvider();
    
    var s = serviceProvider.GetRequiredService<Services>(); // Should work now
