    public static void Main(string[] args)
    {
        var host = new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<Startup>()
            .UseApplicationInsights()
            .CaptureStartupErrors(true) // useful for debugging
            .UseSetting("detailedErrors", "true") // what it says on the tin
            .Build();
        host.Run();
    }
