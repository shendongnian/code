    IWebHost host;
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
        hosrt.Start(); //Starts listening on the configured addresses.
    }
    //... later call Stop() on host to gracefully shut down.
