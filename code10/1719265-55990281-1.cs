    public async Task TalkInChannel() //1
    {
       DiscordSocketClient _client = new DiscordSocketClient(); //2
       var channel = _client.GetChannel(Channel ID) as SocketGuildChannel; //3
       await channel.SendMessageAsync("Message Here!"); //4
    }
