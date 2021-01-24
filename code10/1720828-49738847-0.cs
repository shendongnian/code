    var message = activity as IMessageActivity;
    using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, message))
    {
        var botDataStore = scope.Resolve<IBotDataStore<BotData>>();
        var key = Address.FromActivity(message);
    
        ConversationReference r = new ConversationReference();
        var userData = await botDataStore.LoadAsync(key, BotStoreType.BotUserData, CancellationToken.None);
    
        userData.SetProperty("key 1", "value1");
        userData.SetProperty("key 2", "value2");
    
        await botDataStore.SaveAsync(key, BotStoreType.BotUserData, userData, CancellationToken.None);
        await botDataStore.FlushAsync(key, CancellationToken.None);
    }
