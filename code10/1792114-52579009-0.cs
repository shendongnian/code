        [Command("respects"), Alias("F")]  
        [RequireBotPermission(GuildPermission.AddReactions)]
        public async Task Respects(SocketGuildUser user)
        {
            var emoji = new Emoji("\uD83C\uDDEB");
            string message = $"Press F to pay respects to {user.Mention}:";
            var sent = await Context.Channel.SendMessageAsync(message);
            await sent.AddReactionAsync(emoji);
        }
