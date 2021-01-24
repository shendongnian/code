    [Summary("The Game Module")]
    public class ManualGameManagement : ModuleBase
    {
        [Command("Win", RunMode = RunMode.Sync)]
        [Summary("Increments a user's win counter")]
        public async Task WinAsync([Summary("The user")]params SocketGuildUser[] users)
        {
          //Do stuff...
        }
    }
