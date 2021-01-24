	public async Task<HttpResponseMessage> Post([FromBody]Microsoft.Bot.Connector.Activity activity, CancellationToken token)
	{
		// Send Typing messages
		var typingCancellation = new CancellationTokenSource(TimeSpan.FromSeconds(30));
		var typingTask = SendTypingActivityUntilCancellation(activity, TimeSpan.FromSeconds(2), typingCancellation.Token);
		
		try
		{
			// Activity treatment
			if (activity.Type == ActivityTypes.Message)
			{
				// ...
			}
			else if (activity.Type == ActivityTypes.Event && activity.ChannelId == ChannelEnum.directline.ToString())
			{
				// ...
			}
			typingCancellation.Cancel();
			await typingTask;
			return Request.CreateResponse(HttpStatusCode.OK);
		}
		catch (Exception e)
		{
			typingCancellation.Cancel();
			await typingTask;
			return Request.CreateResponse(HttpStatusCode.InternalServerError);
		}
	}
	
	public async Task SendTypingActivityUntilCancellation(Activity activity, TimeSpan period, CancellationToken cancellationtoken)
	{
		try
		{
			do
			{
				var connector = new ConnectorClient(new Uri(activity.ServiceUrl));
				Activity isTypingReply = activity.CreateReply();
				isTypingReply.Type = ActivityTypes.Typing;
				
				if (cancellationtoken.IsCancellationRequested == false)
				{
					await connector.Conversations.ReplyToActivityAsync(isTypingReply);
				}
				
                // Check again if token has not been canceled during the reply delay
				if (cancellationtoken.IsCancellationRequested == false)
				{
					await Task.Delay(period);
				}
			}
			while (cancellationtoken.IsCancellationRequested == false);
		}
		catch (OperationCanceledException)
		{
			//nothing to do.
		}
	}
