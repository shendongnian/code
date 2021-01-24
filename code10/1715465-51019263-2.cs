    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
      services.Configure<GoogleApiConfig>_appConfiguration.GetSection("Authentication:Google"));
        services.Configure<MicrosoftApiConfig>_appConfiguration.GetSection("Authentication:Microsoft"));
      services.Configure<SendgridApiConfig>_appConfiguration.GetSection("Sendgrid"));
