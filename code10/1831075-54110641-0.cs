    private async Task clientReady()
        {
            Channel = Client.GetChannel(525085451598692364) as SocketTextChannel;
            if (!(Channel is ISocketMessageChannel msgChannel)) return;
            var msgId = (await Channel.GetMessagesAsync(1).FlattenAsync()).FirstOrDefault().Id;
            var msg = await msgChannel.GetMessageAsync(msgId);
            if (msg != null) Console.WriteLine(msg.Content + " ID: ");
        }
