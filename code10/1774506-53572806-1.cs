    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddTransient<ClaimCookie>();
        ...rest of code ommited...
    }
