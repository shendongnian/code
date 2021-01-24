    _bots=new[]{ new Bot(),new Bot()};
    public async Task<bool> StartBotInstanceAsync(int instance)
    {
         try  
         {
              await _bots[instance-1].StartAsync();
              return true;
         }
         catch(Exception ex)
         {
             Logger.Info(ex.ToString());
             return false;
         }
    }
