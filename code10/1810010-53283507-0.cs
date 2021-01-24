    private virtual void ConfigureDatabase(IServiceCollection services)
    {
        services.AddDbContext<MyContext>(o =>
            o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    }
