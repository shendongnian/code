    	public class status : ModuleBase<SocketCommandContext>
	{
  		private DiscordSocketClient _client;
 
    public CommandHandler(IServiceProvider provider)
    {
    	bot = map.GetService<DiscordSocketClient>();
        bot.Ready += SetGame;
    }
    public async Task StatusAsync()
    {
     await _client.SetGameAsync("eating doritos");
    }
    }
  
