	/// <summary>
	/// Here is the method we're using for the PromptAsyncDelgate.
	/// </summary>
	private static async Task<FormPrompt> PromptAsync(IDialogContext context, FormPrompt prompt,
		MyClass state, IField<MyClass> field)
	{
		var preamble = context.MakeMessage();
		var promptMessage = context.MakeMessage();
		if (field.Name == nameof(ColorField))
		{
			promptMessage.Text =
				"I have colors in mind, but need your help to choose the best one.";
			promptMessage.SuggestedActions = new SuggestedActions()
			{
				Actions = new List<CardAction>()
				{
					new CardAction(){ Title = "Blue", Type=ActionTypes.ImBack, Value="Blue" },
					new CardAction(){ Title = "Red", Type=ActionTypes.ImBack, Value="Red" },
					new CardAction(){ Title = "Green", Type=ActionTypes.ImBack, Value="Green" },
				}
			};
		}
		else
		{
			if (prompt.GenerateMessages(preamble, promptMessage))
			{
				await context.PostAsync(preamble);
			}
		}
		await context.PostAsync(promptMessage);
		return prompt;
	}
