    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services
            services.AddHealthChecks();
    
            services.AddMvc();
    
            // Register your consumers if the need dependencies
            services.AddScoped<SomeDependency>()
            services.AddScoped<OrderConsumer>();
    
            // Register MassTransit
            services.AddMassTransit(
                provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    var host = cfg.Host("localhost", host => 
                    { 
                        host.Username("guest");
                        host.Password("guest");
                    });
    
                    cfg.ReceiveEndpoint(host, "submit-order", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(x => x.Interval(2, 100));
    
                        ep.Consumer<OrderConsumer>(provider);
                    });
                }),
                x => x.AddConsumer<OrderConsumer>());
        }
    
        // everything else
    }
