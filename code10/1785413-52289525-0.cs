    var host = new HostBuilder()                 
        .ConfigureServices((hostContext, services) =>
        {
            services.AddLogging();
                .AddEntityFrameworkSqlServer()
                .AddDbContext<EmailDBContext>(option => option.UseSqlServer(configuration.GetConnectionString("connection_string")))
                .AddScoped<ISMTPService, SMTPService>()
                .AddScoped<IEmailService, EmailService>()
                
            services.AddScoped<IRabbitMQPersistentConnection, RabbitMQPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<RabbitMQPersistentConnection>>();
                var _emailService = sp.GetRequiredService<IEmailService>(); // Working now. :)
                var factory = new ConnectionFactory()
                {
                    HostName = "localhost"
                };                          
                return new RabbitMQPersistentConnection(logger, factory, _emailService);
            });
        })
        .Build();
