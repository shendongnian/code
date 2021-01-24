    public void ConfigureServices(IServiceCollection services)
    {
        //...
        // Add to bottom of ConfigureServices
        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = $"/Account/Login";
        });
    }
