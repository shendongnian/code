	await context.PostAsync("please reply 3 message");
	context.Wait(ThreeMessageReceivedAsync);
	private async Task ThreeMessageReceivedAsync(IDialogContext context,
		IAwaitable<IMessageActivity> result)
	{
		context.PrivateConversationData.TryGetValue<string>("FirstMessage", out string firstMessage);
		context.PrivateConversationData.TryGetValue<string>("SecondMessage", out string secondMessage);
		context.PrivateConversationData.TryGetValue<string>("ThirdMessage", out string thirdMessage);
		
		var message = await result;
		
		if(string.IsNullOrEmpty(firstMessage))
		{
			context.PrivateConversationData.SetValue<string>("FirstMessage", message.Text);
			context.Wait(ThreeMessageReceivedAsync);
		}
		else if(string.IsNullOrEmpty(secondMessage))
		{
			context.PrivateConversationData.SetValue<string>("SecondMessage", message.Text);
			context.Wait(ThreeMessageReceivedAsync);
		}
		else if(string.IsNullOrEmpty(thirdMessage))
		{
			context.PrivateConversationData.SetValue<string>("ThirdMessage", message.Text);
			
			// you have got all three message, do your logic to it
			// if you want to join all three message, use variable firstMessage, secondMessage and message.Text for third
		}
	}
	hope above helps.
