        public async Task Announce() // 1
    {
        DiscordSocketClient _client = new DiscordSocketClient(); // 2
        ulong id = 123456789012345678; // 3
        var chnl = _client.GetChannel(id) as IMessageChannel; // 4
        await chnl.SendMessageAsync("Announcement!"); // 5
    }
