    public void ConfigureServices(IServiceCollection services)
    {
        var section = Configuration.GetSection("ProviderA");
        services.Configure<Config>(section);
    }
