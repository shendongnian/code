    async Task HandleCommandAsync(SocketMessage messageParam)
    {
        // Filter out system messages
        var message = messageParam as SocketUserMessage;
        if (message == null)
        {
            return;
        }
        // Filter out non commands
        int argPos = 0;
        if (!(message.HasCharPrefix('!', ref argPos) || 
            message.HasMentionPrefix(_client.CurrentUser, ref argPos)) ||
            message.Author.IsBot)
            return;
    
        //...
    }
