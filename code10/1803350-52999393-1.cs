    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IWordService, WordService>();
        ....
    }
