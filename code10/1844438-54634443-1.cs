    IWebHost host;
    [OneTimeSetUp]
    public void SetupHost() {
        var webhostBuilder = new WebHostBuilder()
            .UseKestrel()
            .UseIISIntegration()
            .UseContentRoot("root")
            .UseStartup(typeof(Startup))
            .ConfigureAppConfiguration((builderContext, config) =>
            {
                config.AddJsonFile("config1", false);
                config.AddJsonFile("config2", false);
            });
    
        host = webhostBuilder.Build();
        host.Start(); //Starts listening on the configured addresses.
    }
