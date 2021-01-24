    [Command("ping")]
    public async Task Ping(IUser user)
    {
      await Context.Channel.SendMessageAsync(user.ToString());
    }
