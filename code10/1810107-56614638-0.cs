    public class DebugModule : ModuleBase<SocketCommandContext>
    {
        [Command("read")]
        [Summary("Reads the contents of a dropped file.")]
        public async Task Read() {
            using(var client = new HttpClient())
                await ReplyAsync(await client.GetStringAsync(Context.Message.Attachments.First().Url));
        }
    }
