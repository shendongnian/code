    public async Task MainAsync()
        {
            client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Debug
            });
            Commands = new CommandService(new CommandServiceConfig
            {
                CaseSensitiveCommands = false,
                DefaultRunMode = RunMode.Async,
                LogLevel = LogSeverity.Debug
            });
            client.MessageReceived += Client_MessageReceived;
            await Commands.AddModulesAsync(Assembly.GetEntryAssembly());
            client.Ready += Client_Ready;
            client.Log += Client_Log;
            client.UserJoined += Client_AnnounceJoinUser;
            client.GuildMemberUpdated += Client_AnnounceUpgradeUser;
            string token;
            FileStream stream = new FileStream($"{Directory.GetCurrentDirectory()}/data/token.txt", FileMode.Open, FileAccess.Read);
            StreamReader readToken = new StreamReader(stream);
            token = readToken.ReadToEnd();
            
            await client.LoginAsync(TokenType.Bot, token);
            
            await client.StartAsync();
            await Task.Delay(-1);
        }
