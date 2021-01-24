	[Command("Test")]
	[Alias("t")]
	public async Task Test()
	{
		ulong myGuildId = 389484134214664193;
		ulong myChannelId = 391228056779620352;
		var guild = Context.Client.Guilds.FirstOrDefault(g => g.Id == myGuildId);
		var voiceChannel = guild.Channels.FirstOrDefault(c => c.Id == myChannelId);
		var users = voiceChannel.Users;
		foreach (var user in users)
		{
			var dm = await user.GetOrCreateDMChannelAsync();
			await dm.SendMessageAsync("Greetings");
		}
	}
