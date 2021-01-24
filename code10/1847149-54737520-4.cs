    public static ServiceProvider Build()
    {
        var services = new ServiceCollection()
            .AddTransient<IReadFile, ReaFile>()
            .AddTransient<IWriteFile, WriteFile>()
            .AddTransient<IGenerateCsv ,GenerateCsv>()
            .AddTransient<IGenerateTxt,GenerateTxt>()
            .BuildServiceProvider();
        return services;
    }
