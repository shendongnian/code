          var botConfig = BotConfiguration.Load(botFilePath ?? @".\MyBot.bot", secretKey);
          services.AddSingleton(sp => botConfig ?? throw new InvalidOperationException($"The .bot config file could not be loaded. ({botConfig})"));
          var connectedServices = new BotServices(botConfig);
          services.AddSingleton<BotServices>(sp => connectedServices);
          services.AddBot<MyBot>(options =>
           {
               //all the bot configuration code
           }
