    public class Help : ModuleBase<SocketCommandContext>
    {
        [Command("test")]
        public async Task TestAsync()
        {
            await Context.Client.SetGameAsync("eating doritos");
            await Task.CompletedTask;
        }
    }
