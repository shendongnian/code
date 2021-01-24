    /*In latest bot version v4, you can get userName using following code*/
    
    public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
    {
    var userName = turnContext.Activity.From.Name;
    await turnContext.SendActivityAsync($"Welcome - {userName }");
    }
