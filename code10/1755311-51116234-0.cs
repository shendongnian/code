    var builder = new WebHostBuilder()
                .UseKestrel()
                ...
    
                .UseIISIntegration()
                .ConfigureServices(servicesCollection =>
                {
                    servicesCollection.AddSingleton<Serilog.ILogger>(logger);              
                })
                .UseDefaultServiceProvider((context, options) =>
                {
                    options.ValidateScopes = 
    context.HostingEnvironment.IsDevelopment();
                });
