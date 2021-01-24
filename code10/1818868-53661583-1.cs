    static async Task Main(string[] args)
        {
            Console.WriteLine("Starting PreProcessor Application ");
            IServiceCollection servicesCollection = new ServiceCollection();
            try
            {
                ConfigParameters.LoadSettings(args);
                servicesCollection.AddScoped<IMessageQueue, ActiveMQHandler>(x =>
                {
                    return new ActiveMQHandler("127.0.0.1");
                });
                DependencyInjection.AddServices(servicesCollection);
            }
            catch (Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error in setting config parameters {ex.Message}");
                return;
            }
            IHost host = new HostBuilder()
                .ConfigureHostConfiguration(configHost =>
                {
                    configHost.AddCommandLine(args);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddLogging();
                    services.AddHostedService<MainService>();                    
                })
                .Build();            
            await host.RunAsync();
        }
