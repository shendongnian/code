    public static async Task Main(string[] args)
    {
        var host = CreateWebHostBuilder(args).Build();
        using (var scope = host.Services.CreateScope())
        {
            var dataSeeder = scope.ServiceProvider.GetService<DataSeeder>();
            await dataSeeder.EnsureSeedDataAsync();
        }
        await host.RunAsync();
    }
