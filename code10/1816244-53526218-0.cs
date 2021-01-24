    // You can lazily create the IMapper, or if you prefer, use
    // a concrete value.
    services.AddSingleton<IMapper>(() => mappingConfig.CreateMapper());
    // Make your EmployeesRepo implement IEmployeesRepo
    services.AddTransient<IEmployeesRepo, EmployeesRepo>();
    // I'm guessing but you'll have the connection string somewhere like this.
    // Also using a DbContextPool instead has benefits (though not required)
    services.AddDbContextPool<EFContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Data")));
