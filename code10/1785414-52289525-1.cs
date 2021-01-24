    var host = new HostBuilder()                 
        .ConfigureServices((hostContext, services) =>
        {
            services.AddLogging();
            services.AddEntityFrameworkSqlServer();
            services.AddDbContext<EmailDBContext>(option => option.UseSqlServer(configuration.GetConnectionString("connection_string")));
            services.AddScoped<ISMTPService, SMTPService>();
            services.AddScoped<IEmailService, EmailService>();
                
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
