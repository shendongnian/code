	Conversation.UpdateContainer(
		builder =>
		{
			builder.RegisterModule(new AzureModule(Assembly.GetExecutingAssembly()));
			var store = new InMemoryDataStore(); // volatile in-memory store
			builder.Register(c => store)
				.Keyed<IBotDataStore<BotData>>(AzureModule.Key_DataStore)
				.AsSelf()
				.SingleInstance();
		});
	GlobalConfiguration.Configure(WebApiConfig.Register);
