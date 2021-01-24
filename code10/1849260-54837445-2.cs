	private async Task<bool> IsTurnInterruptedAsync(ITurnContext turnContext)
	{
		var dc = await _dialogs.CreateContextAsync(turnContext);
		var topIntent = turnContext.TurnState.Get<string>("topIntent");
		// See if there are any conversation interrupts we need to handle.
		if (topIntent.Equals(CancelIntent))
		{
            // . . .
