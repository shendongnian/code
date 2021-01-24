    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMassTransit(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
        {
            var host = cfg.Host(new Uri("rabbitmq://localhost"), h =>
            {
                h.Username("guest");
                h.Password("guest");
            });
            cfg.ReceiveEndpoint(host, "message_one", ep => ep.Consumer<MessageOneConsumer>(provider));
            cfg.ReceiveEndpoint(host, "message_two", ep => ep.Consumer<MessageTwoConsumer>(provider));
        }));
    }
