    private async Task HandleCommandAsync(SocketMessage arg)
    {
        var message = arg as SocketUserMessage;
        if (message is null || message.Author.IsBot) return;
        int argPos = 0;
        if (message.HasStringPrefix("", ref argPos))
        {
            var context = new SocketCommandContext(_client, message);
            var result = await _commands.ExecuteAsync(context, argPos, _services);
            if (!result.IsSuccess)
                Console.WriteLine(result.ErrorReason);
        }
        if (message.content.contains(_client.CurrentUser.Mention))
        {
            var embed = new EmbedBuilder();
            embed.WithImageUrl("https://cdn.discordapp.com/attachments/138522037181349888/438774275546152960/Ping_Discordapp_GIF-downsized_large.gif");
            await ReplyAsync("", false, embed.Build());
        }
