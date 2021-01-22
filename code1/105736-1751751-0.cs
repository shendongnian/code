    public bool
       Ping (string host, int attempts, int timeout)
       {
          System.Net.NetworkInformation.Ping  ping = 
                                           new System.Net.NetworkInformation.Ping ();
    
          System.Net.NetworkInformation.PingReply  pingReply;
          
          for (int i = 0; i < attempts; i++)
          {
             try
             {
                pingReply = ping.Send (host, timeout); 
                
                // If there is a successful ping then return true.
                if (pingReply != null &&
                    pingReply.Status == System.Net.NetworkInformation.IPStatus.Success)
                   return true;
             }
             catch
             {
                // Do nothing and let it try again until the attempts are exausted.
                // Exceptions are thrown for normal ping failurs like address lookup
                // failed.  For this reason we are supressing errors.
             }
          }
          
          // Return false if we can't successfully ping the server after several attempts.
          return false;
       }
