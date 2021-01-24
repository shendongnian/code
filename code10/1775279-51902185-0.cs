    public async Task SampleCommand(string user="", [Remainder]string message="")
    {
        IUser subject = null;
        if (user != "")
        {
            var guilds = (await Context.Client.GetGuildsAsync(Discord.CacheMode.AllowDownload));
            var users = new List<IUser>();
            foreach (var g in guilds)
                users.AddRange(await g.GetUsersAsync(CacheMode.AllowDownload));
            users = users.GroupBy(o => o.Id).Select(o => o.First()).ToList();
            var search = users.Where(o => o.Username.ToLower().Contains(user.ToLower()) || Context.Message.MentionedUserIds.Contains(o.Id) || o.ToString().ToLower().Contains(user.ToLower())).ToArray();
            if (search.Length == 0)
            {
                await ReplyAsync("***Error!*** *Couldn't find that user.*");
                return;
            }
            else if (search.Length > 1)
            {
                await ReplyAsync("***Error!*** *Found more than one matching users.*");
                return;
            }
            subject = search.First();
        }
        // ...
        // execute command
