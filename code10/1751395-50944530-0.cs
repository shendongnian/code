    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<TaskQueue>();
        services.AddSingleton<SerialQueue>();
        // the rest
    }
