    public void ConfigureServices(IServiceCollection services) {
        //...
        services.AddDbContext<UserContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("UserDatabase"));
        );
        //...
    }
