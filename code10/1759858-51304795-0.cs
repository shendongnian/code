    public void ConfigureServices(IServiceCollection services)
    {
       ...    
       services.Configure<ConnectionStringConfig>(Configuration);
    }
