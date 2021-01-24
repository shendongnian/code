    private async Task OnMessageReceived(SocketMessage socketMessage)
    {
        // We only want messages sent by real users 
        if (!(socketMessage is SocketUserMessage message))
            return;
      
        // This message handler would be called infinitely
        if (message.Author.Id == _discordClient.CurrentUser.Id)
            return;
        await socketMessage.Channel.SendMessageAsync(socketMessage.Content);
    }
