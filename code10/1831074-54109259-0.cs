    private async Task OnReadyAsync()
    {
        // attempt to get the channel
        var channel = _client.GetChannel(_channelId);
        // pattern match to SocketMessageChannel, the standard type required for a channel to be a messageable one
        if (!(channel is ISocketMessageChannel msgChannel)) return;
        // await the GetMessageAsync task to get the result of this task
        var msg = await msgChannel.GetMessageAsync(_msgId);
        // print Content if msg exists
        if (msg != null) Console.WriteLine(msg.Content);
    }
