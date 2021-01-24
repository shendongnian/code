    private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
    {
        var activity = await result as Activity;
        IBotDataStore<BotData> table = new TableBotDataStore(ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
    //use the type of state data you need
        var userData = await table.LoadAsync(Address.FromActivity(activity), BotStoreType.BotUserData, CancellationToken.None );
        var privateConvoData = await table.LoadAsync(Address.FromActivity(activity), BotStoreType.BotPrivateConversationData, CancellationToken.None );
        var convoData = await table.LoadAsync(Address.FromActivity(activity), BotStoreType.BotConversationData, CancellationToken.None);
    //in this case I am just replying with the data, but do what you need with it here
        var reply = activity.CreateReply(userData.Data.ToString());
        var reply2 = activity.CreateReply(privateConvoData.Data.ToString());
        var reply3 = activity.CreateReply(convoData.Data.ToString());
        await context.PostAsync(reply);
        await context.PostAsync(reply2);
        await context.PostAsync(reply3);
        context.Wait(MessageReceivedAsync);
    }
