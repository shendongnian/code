    public void ConfigureServices(IServiceCollection services)
    {
        ...
        EmailSettings emailSettings = new EmailSettings();
        Configuration.GetSection("EmailSettings").Bind(emailSettings);
        services.AddSingleton(emailSettings);
    }
