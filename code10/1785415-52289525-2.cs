      .ConfigureServices((hostContext, services) =>
               {
                   services.AddLogging();
                   services.AddHostedService<LifetimeEventsHostedService>();
                   services.AddHostedService<TimedHostedService>();
                   services.AddEntityFrameworkSqlServer();
                   services.AddDbContext<EmailDBContext>(option => option.UseSqlServer(configuration.GetConnectionString("connection_string")));
                   services.AddSingleton<IEmailConfiguration>(configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
                   services.AddScoped<ISMTPService, SMTPService>();
                   services.AddScoped<IEmailService, EmailService>();
                   services.AddScoped<IRabbitMQPersistentConnection, RabbitMQPersistentConnection>(sp =>
                   {
                       var logger = sp.GetRequiredService<ILogger<RabbitMQPersistentConnection>>();
                       var _emailService = sp.GetRequiredService<IEmailService>();                      
                       var _rabbitMQConfiguration = configuration.GetSection("RabbitMQConfiguration").Get<RabbitMQConfiguration>();
                       var factory = new ConnectionFactory()
                       {
                           HostName = _rabbitMQConfiguration.EventBusConnection
                       };
                       if (!string.IsNullOrEmpty(_rabbitMQConfiguration.EventBusUserName))
                       {
                           factory.UserName = _rabbitMQConfiguration.EventBusUserName;
                       }
                       if (!string.IsNullOrEmpty(_rabbitMQConfiguration.EventBusPassword))
                       {
                           factory.Password = _rabbitMQConfiguration.EventBusPassword;
                       }
                       return new RabbitMQPersistentConnection(logger, factory, _emailService);
                   });
               })
