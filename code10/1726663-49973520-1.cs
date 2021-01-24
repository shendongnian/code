    public void ConfigureServices(IServiceCollection services)
    {
            services.AddDbContext<TestDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Cn")));
    }
