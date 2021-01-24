    Conversation.UpdateContainer(
        builder =>
        {
            builder.RegisterModule(new AzureModule(Assembly.GetExecutingAssembly()));
    
            var store = new DocumentDbBotDataStore(docDbEmulatorUri, docDbEmulatorKey);
    
            builder.Register(c => store)
                .Keyed<IBotDataStore<BotData>>(AzureModule.Key_DataStore)
                .AsSelf()
                .SingleInstance();
    
            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);
    
        });
