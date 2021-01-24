    var builder = new HostBuilder()
                .ConfigureAppConfiguration((builderContext, cb) =>
                {
                    IHostingEnvironment env = builderContext.HostingEnvironment;
                    cb.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                })
                .ConfigureWebJobs(b =>
                {
                    b.AddAzureStorage(o => 
                    {
                        o.MaxDequeueCount = 1;
                    })
                    .AddServiceBus(c =>
                    {
                        c.MessageHandlerOptions.MaxConcurrentCalls = 1;
                    });
                })
                .ConfigureLogging((webHostBuilder, loggingBuilder) =>
                {
                    loggingBuilder.AddConsole();
                    loggingBuilder.AddDebug();
                })
                .ConfigureServices((hb, sc) =>
                {
                    string connectionString = hb.Configuration.GetConnectionString("DefaultConnection");
                    sc.AddScoped<Functions, Functions>();
                    ...
                });
            builder.RunConsoleAsync().GetAwaiter().GetResult();
