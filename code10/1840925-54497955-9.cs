    // Added as part of the example
    services.AddHttpContextAccessor();
    // Replace registration with this line:
    services.AddScoped<DbConnectionInfo>();
    // Register the DbContext
    services.AddScoped<MyContext>();
