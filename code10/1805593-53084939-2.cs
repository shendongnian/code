    using System;
    using MassTransit.RabbitMqTransport;
    
    namespace MassTransit.TestCode
    {
        public static class BusConfigurationExtensions
        {
            public static void ConfigureEndpoint<T>(this IRabbitMqBusFactoryConfigurator cfg,
                IRabbitMqHost host, string endpointName, IServiceProvider provider)
            where T : class, IConsumer
                => cfg.ReceiveEndpoint(host, endpointName, ep => ep.Consumer<T>(provider));
        }
    }
