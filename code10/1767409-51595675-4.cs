    //Get this value from some configuration
    string providerType = Configuration.GetValue<string>("DatabaseProvider");
    //and the connection string for the database
    string connectionString = Configuration.GetConnectionString(providerType);
    
    services.AddDbContext<AppDbContext>(options => {
        if (providerType == "MSSQL")
            options.UseSqlServer(connectionString);
        else if (providerType == "SQLite")
            options.UseSqlite(connectionString);
    });
    services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
