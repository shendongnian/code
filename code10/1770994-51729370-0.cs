    public static void Main(string[] args) =>
        MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
    public static async Task MainAsync(string[] args)
    {
        var host = CreateWebHostBuilder(args).Build();
        // do something
        await host.RunAsync().ConfigureAwait(false);
    }
    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
