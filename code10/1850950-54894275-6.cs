    public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
    {
        var activity = turnContext.Activity;
    
        var dc = await Dialogs.CreateContextAsync(turnContext);
    
        if (activity.Text == "Restart Dialog A")
        {
            await dc.CancelAllDialogsAsync();
            await dc.BeginDialogAsync(nameof(DialogA));
        }
