    public void ConfigureServices(IServiceCollection services)
    {
        services.AddBot<TestEchoBotBot>(options =>
        {
            IStorage dataStore = new MemoryStorage();
            options.State.Add(new ConversationState(dataStore));
            options.Middleware.Add(new AutoSaveStateMiddleware(options.State.ToArray()));
    
            var secretKey = Configuration.GetSection("botFileSecret")?.Value;
            var botFilePath = Configuration.GetSection("botFilePath")?.Value;
    
            // Loads .bot configuration file and adds a singleton that your Bot can access through dependency injection.
            var botConfig = BotConfiguration.Load(botFilePath ?? @".\TestEchoBot.bot", secretKey);
            services.AddSingleton(sp => botConfig ?? throw new InvalidOperationException($"The .bot config file could not be loaded. ({botConfig})"));
    
            // Retrieve current endpoint.
            var environment = _isProduction ? "production" : "development";
            var service = botConfig.Services.Where(s => s.Type == "endpoint" && s.Name == environment).FirstOrDefault();
            if (!(service is EndpointService endpointService))
            {
                throw new InvalidOperationException($"The .bot file does not contain an endpoint with name '{environment}'.");
            }
    
            options.CredentialProvider = new SimpleCredentialProvider(endpointService.AppId, endpointService.AppPassword);
        });
    
        services.AddSingleton(sp =>
        {
            var options = sp.GetRequiredService<IOptions<BotFrameworkOptions>>().Value;
            var conversationState = options.State.OfType<ConversationState>().FirstOrDefault();
            var accessors = new TestEchoBotAccessors(conversationState)
            {
                ConversationDialogState = conversationState.CreateProperty<DialogState>("DialogState")
            };
            return accessors;
        });
    }
