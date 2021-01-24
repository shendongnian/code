    public async Task StartAsync()
    {
        await Client.StartAsync();
        Client.MessageReceived += Client_MessageReceived;
        Client.Ready += Client_Ready;
        Logger.WriteLog("Bot started");
        await Task.Delay(-1);
    }
    
    private async Task Client_Ready()
    {
        var channel = Client.GetChannel(414543303187496962);
    }
