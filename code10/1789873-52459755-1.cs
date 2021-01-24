    [Command("unban")]
    [RequireBotPermission(GuildPermission.BanMembers)]
    public async Task UnbanTask(ulong userId)
    {
        await Context.Guild.RemoveBanAsync(userId);
        // Unbanned
    }
