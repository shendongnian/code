    public static class RetryUtility
    {
       public static void RetryAction( Action action, int numRetries, int retryTimeout )
       {
           if( action == null )
               throw new ArgumenNullException("action"); // slightly safer...
           while( numRetries-- > 0 )
           {
              try {  action();  }
              catch
              { 
                  if( numRetries == 0 ) throw;
                  else Thread.Sleep( retryTimeout );
               }
           }
       }
    }
