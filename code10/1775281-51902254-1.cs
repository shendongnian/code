    [Command("ping")]
    public async Task Ping(SocketGuildUser user)
    {
       await Context.Channel.SendMessageAsync(user.Username);
    }
