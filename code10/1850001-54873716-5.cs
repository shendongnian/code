    public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
    {
        var activity = turnContext.Activity;
    
        var dc = await Dialogs.CreateContextAsync(turnContext);
    
        if (activity.Type == ActivityTypes.Message)
        {
            if (activity.Text.ToLower() == "open dialog b")
            {
                await dc.RepromptDialogAsync();
            };
    ...
