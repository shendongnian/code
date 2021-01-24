    // the async event handler returns void
    private async void OnButtonBroadCast(object sender, ...)
    {
        // this is the only function that returns void instead of Task
        await this.BroadCast(...);
    }
    async Task Broadcast(string articleLink, string articleCategory)
    {
        var targetChats = ...
        await InternalBroadcastAsync(articleLink, targetChats);
    }
    async Task InternalBroadcastAsync(string articleLink, 
        IEnumerable<TelegramChannel> targetChats)
    {
        Logger.Info(...);
        foreach (var chat in targetChats)
        {
            try
            {
                var broadcastedMessage = await _telegramBotClient.SendTextMessageAsync(...);
                SaveBroadcastedMessage(broadcastedMessage);
            }
            catch (Exception exception)
            {
                ...
            }
        }
    }
