    new HostBuilder()
        .ConfigureServices((hostContext, services) =>
        {
            services
            .AddDbContext<Context1>()
            .AddDbContext<Context2>((serviceProvider, options) => {
                var context1 = serviceProvider.GetService<Context1>();
                var connectionString = /* get Connection string from context1 here */ 
                options.UseSqlServer(connectionString);
            })
            .AddHostedService<MyHostedService>();
        });
