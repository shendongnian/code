	private SimplePublisher CreateSimplePublisher(int maxItems, int maxSizeBytes, TimeSpan maxDelay)
	{
		var credential = Credential.IsCreateScopedRequired ?
			Credential.CreateScoped(PublisherClient.DefaultScopes) : Credential;
		var channel = new Channel(
			PublisherClient.DefaultEndpoint.Host,
			PublisherClient.DefaultEndpoint.Port,
			credential.ToChannelCredentials());
        //Add a specific timeout for the publish operation
		var publisherClientSettings = new PublisherSettings
		{
			PublishSettings = CallSettings.FromCallTiming(CallTiming.FromTimeout(TimeSpan.FromMinutes(60)))
		};
		var publisherClient = PublisherClient.Create(channel,publisherClientSettings);
		return SimplePublisher.Create(
			new TopicName(Project, Topic),
			new[] { publisherClient },
			new SimplePublisher.Settings
			{
				BatchingSettings = new BatchingSettings
				(
					elementCountThreshold: maxItems,
					byteCountThreshold: maxSizeBytes,
					delayThreshold: maxDelay
				)
			});
	}
