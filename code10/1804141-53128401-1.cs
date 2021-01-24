    [Command("test")]
    [Alias("t")]
    public async Task Test()
    {
        //validation
        if (!IsFromGuildChat())
            return;
        await ReplyAsync("This is only called from Guild Chat!");
    }
