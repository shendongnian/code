    public class Help : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        public async Task HelpAsync(SocketGuildUser user)
        {
            await ReplyAsync($"{user.Mention} needs a lot of help!");
        }
    }
