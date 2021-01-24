	public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
	{
		// DEMO PURPOSE: echo all incoming activities
		Activity reply = activity.CreateReply(Newtonsoft.Json.JsonConvert.SerializeObject(activity, Newtonsoft.Json.Formatting.None));
		var connector = new ConnectorClient(new Uri(activity.ServiceUrl));
		connector.Conversations.SendToConversation(reply);
		// Process each activity
		if (activity.Type == ActivityTypes.Message)
		{
			await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());
		}
		// Webchat: getting an "event" activity for our js code
		else if (activity.Type == ActivityTypes.Event && activity.ChannelId == "webchat")
		{
			var receivedEvent = activity.AsEventActivity();
			if ("myCustomEvent".Equals(receivedEvent.Name, StringComparison.InvariantCultureIgnoreCase))
			{
				// DO YOUR GREETINGS FROM HERE
			}
		}
		// Sample for Skype: in ContactRelationUpdate event
		else if (activity.Type == ActivityTypes.ContactRelationUpdate && activity.ChannelId == "skype")
		{
			// DO YOUR GREETINGS FROM HERE
		}
		// Sample for emulator, to debug locales
		else if (activity.Type == ActivityTypes.ConversationUpdate && activity.ChannelId == "emulator")
		{
			foreach (var userAdded in activity.MembersAdded)
			{
				if (userAdded.Id == activity.From.Id)
				{
					// DO YOUR GREETINGS FROM HERE
				}
			}
		}
		var response = Request.CreateResponse(HttpStatusCode.OK);
		return response;
	}
