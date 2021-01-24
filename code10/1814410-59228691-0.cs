            // Service collection
            IServiceCollection serviceCollection = new ServiceCollection()
                .AddLogging(loggingBuilder =>
                    loggingBuilder
                        .AddSerilog(SwitchableLogger.Instance, true)
                        .AddSerilogConfigurationLoader(configuration, SwitchableLogger.Instance)
                    );
            // Services
            using (var services = serviceCollection.BuildServiceProvider())
            {
                // Create logger
                Microsoft.Extensions.Logging.ILogger logger = services.GetService<Microsoft.Extensions.Logging.ILogger<Program>>();
                // Write
                logger.LogInformation("Hello World");
                // Modify config
                config.Set("Serilog:WriteTo:0:Args:OutputTemplate", "[{SourceContext}] {Message:lj}{NewLine}{Exception}");
                configuration.Reload();
                // Write with the previous logger instance, but with different settings
                logger.LogInformation("Hello world again");
            }
