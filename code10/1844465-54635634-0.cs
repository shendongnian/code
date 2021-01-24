    services.AddDbContext<MyDbContext>(cfg =>
    {                
        cfg.UseSqlServer(_config.GetConnectionString("LIMSConnectionString"));
    }, 
    ServiceLifetime.Transient);
