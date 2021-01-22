        static class ActionExtensions
        {
          public static void InvokeAndRetryOnException<T> (this Action action, int retries, TimeSpan retryDelay) where T : Exception
          {
            if (action == null)
              throw new ArgumentNullException("action");
    
            while( retries-- > 0 )
            {
              try
              {
                action( );
                return;
              }
              catch (T)
              {
                Thread.Sleep( retryDelay );
              }
            }
    
            action( );
          }
        }
