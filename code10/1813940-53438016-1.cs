    private void ConfigureServices()
    {
        _serviceProvider = new ServiceCollection()
            .AddScoped<ILeaguesService, LeaguesService>()
            .AddSingleton<statsContext>(GetContext())
            .BuildServiceProvider();
    }
