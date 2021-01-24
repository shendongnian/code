    private void ConfigureServices()
    {
        _serviceProvider = new ServiceCollection()
            .AddScoped<ILeaguesService, LeaguesService>()
            .AddScoped<statsContext>()
            .BuildServiceProvider();
    }
