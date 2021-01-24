    public async Task InitAsync()
    {
        _client = new DiscordSocketClient();
        _client.Ready += OnReady;
        await _client.LoginAsync(TokenType.Bot, _token);
        await _client.StartAsync();
        // method will exit right away after start
        // halt the current task with Task.Delay
        await Task.Delay(-1);
    }
    private async Task OnReady()
    {
        var channel = _client.GetChannel(_channelId) as ISocketMessageChannel;
        // bail if the channel type is not a message one
        if (channel == null) return;
    
        // no need to pass CacheMode and RequestOptions as they are optional
        // 1) CacheMode is default to always download especially if you do not 
        // have it enabled in the first place (see DiscordSocketConfig).
        // 2) RequestOptions should almost never be passed unless your request
        // requires specific "requests."
        // also, we await the task to actually get the result of this inquiry
        var msg = await channel.GetMessageAsync(_channelId);
        if (msg != null) Console.WriteLine(msg.Content);
    }
