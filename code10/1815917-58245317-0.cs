    public void ConfigureServices(IServiceCollection services)
    {
    	services.AddControllers();
    	....
    	services.AddDbContext<Context>(options => { ... });
    	....
    }
