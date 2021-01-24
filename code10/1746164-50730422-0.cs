      public static IHost BuildHost(string[] args) =>
        new HostBuilder()
            .ConfigureServices(services => services.AddSingleton<IHostedService, PrintTimeService>())
            .UseSerilog() // <- Add this line
            .Build();
