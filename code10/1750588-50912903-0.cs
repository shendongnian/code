    [RequireOwner]
    [Command("give"), Alias("Give", "gift", "Gift"), Summary("Used to give or gift people golden coins")]
    public async Task Give(IUser User = null, int Amount = 0)
    {
        SocketGuildUser User1 = Context.User as SocketGuildUser;
        //Give currency to the user.
    }
