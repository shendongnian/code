    using Google.Cloud.Dialogflow.V2;
	
	...
	...
       
	var query = new QueryInput
	{
		Text = new TextInput
		{
			Text = "Something you want to ask a DF agent",
			LanguageCode = "en-us"
		}
	};
	var sessionId = "SomeUniqueId";
	var agent = "MyAgentName";
	var creds = GoogleCredential.FromJson("{ json google credentials file)");
	var channel = new Grpc.Core.Channel(SessionsClient.DefaultEndpoint.Host, 
                  creds.ToChannelCredentials());
	var client = SessionsClient.Create(channel);
	var dialogFlow = client.DetectIntent(
		new SessionName(agent, sessionId),
		query
	);
	channel.ShutdownAsync();
