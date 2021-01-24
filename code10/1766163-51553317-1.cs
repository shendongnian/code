    public static async Task Main(string[] args)
    {
        var hostBuilder = new HostBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<IBusControl>(serviceProvider =>
                {
                    return MassTransit.Bus.Factory.CreateUsingRabbitMq(cfg =>
                    {
                        var host = cfg.Host(new Uri("rabbitmq://localhost"), h =>
                        {
                            h.Username("guest");
                            h.Password("guest");
                        });
                    });
                });
                services.AddScoped<IHostedService, MassTransitHostedService>();
            });
        await hostBuilder.RunConsoleAsync();
    }
