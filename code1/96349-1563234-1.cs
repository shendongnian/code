    public static class RetryUtility
    {
       public static void RetryAction( Action action, int numRetries, int retryTimeout )
       {
           if( action == null )
               throw new ArgumenNullException("action"); // slightly safer...
           do
           {
              try {  action();  }
              catch
              { 
                  if( numRetries == 0 ) throw;
                  else Thread.Sleep( retryTimeout );
               }
           } while( numRetries-- > 0 );
       }
    }
