    private async Task MsgRec(SocketMessage e)
    {
	    var msg = s as SocketUserMessage;
        if (msg == null) return;
	    if (msg.Content.Contains("fuck"))
        {
            var newMsg = msg.Content.Replace("fuck", "f*ck");
            await s.Channel.SendMessageAsync(newMsg);
        }
    }
