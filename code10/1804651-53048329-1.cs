    public async Task<bool> StartBotInstanceAsync(Bot bot)
    {
         try  
         {
              await bot.StartAsync();
              return true;
         }
         catch(Exception ex)
         {
             Logger.Info(ex.ToString());
             return false;
         }
    }
    var myBot=_bots[instance-1];
    var started=await StartBotInstanceAsync(myBot);
