    public async Task UpdateGameBeingPlayed(SocketGuildUser user, SocketUser userAgain)
    {
        string strGuildId = user.Guild.Id.ToString();
        ulong ulongId = Convert.ToUInt64(strGuildId);
        var channel = user.Guild.GetChannel(ulongId) as SocketTextChannel;
        await channel.SendMessageAsync("a user has changed status!");
    }
