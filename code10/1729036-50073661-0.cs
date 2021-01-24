    public static async Task<string> GetUsernameFromId(long userId)
    {
       var retries = 0;
       while (retries++ < MaxRetries)
       {
    
          using (var client = new WebClient())
          {
             try
             {
                ///await client.OpenReadTaskAsync();
                ///blah
                /// 
                break;
             }
             catch (WebException we)
             {
                if (!we.Message.Contains("429"))
                {
                   await Task.Delay(waitTime);
                   continue;
                }
    
                throw;
             }
          }
       }
    }
