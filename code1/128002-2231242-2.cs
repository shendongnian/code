    public static class RetryUtility
    {
       public static void RetryAction(Action action, int numRetries, int retryTimeout)
       {
           if(action == null)
               throw new ArgumenNullException("action"); 
    
           do
           {
              try 
              {  
                  action(); 
                  return;  
              }
              catch
              { 
                  if(numRetries <= 0) 
                      throw;  // Avoid silent failure
                  else
                  {
                      Thread.Sleep(retryTimeout);
                      numRetries--;
                  }
              }
           } 
           while(numRetries > 0);
       }
    }
