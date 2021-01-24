    //sample how I write something into the other conversation
    var conversations = await GetMatchConversion(steps.Context);
    if (conversations.ContainsKey(otherUser.Identifier))
    {
        await steps.Context.Adapter.ContinueConversationAsync(AppId, conversations[otherUser.Identifier],
               async (turnContext, token) =>
               {
                   // Send the user a proactive confirmation message.
                   await turnContext.SendActivityAsync($"{currentUser.Display()} I found a matching user...");
                   var dc = await Dialogs.CreateContextAsync(turnContext);
                   await dc.BeginDialogAsync(nameof(UserFoundDialog));
               },
               cancellationToken);
    }
