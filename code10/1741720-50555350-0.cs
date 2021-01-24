    public void ConfigureServices(IServiceCollection services)
    {
        // using sqlite as example via official docs example
        services.AddDbContext<xxxDbContext>(options => options.UseSqlite("Data Source=blog.db"));
    }
