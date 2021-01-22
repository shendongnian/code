    public delegate void UseServiceDelegate<T>(T proxy);
    
    public static class Service<T>
    {
        public static ChannelFactory<T> _channelFactory = new ChannelFactory<T>(""); 
    
        public static void Use(UseServiceDelegate<T> codeBlock)
        {
            IClientChannel proxy = (IClientChannel)_channelFactory.CreateChannel();
            bool success = false;
 
           Exception mostRecentEx = null;
           for(int i=0; i<5; i++)  // Attempt a maximum of 5 times 
           {
               try
               {
                   codeBlock((T)proxy);
                   proxy.Close();
                   success = true;
               }
               // The following is typically thrown on the client when a channel is terminated due to the server closing the connection.
               catch (ChannelTerminatedException cte)
               {
                  mostRecentEx = cte;
                   proxy.Abort();
                   //  delay (backoff) and retry 
                   Thread.Sleep(1000 * (i + 1)); 
               }
    
               // The following is thrown when a remote endpoint could not be found or reached.  The endpoint may not be found or 
               // reachable because the remote endpoint is down, the remote endpoint is unreachable, or because the remote network is unreachable.
               catch (EndpointNotFoundException enfe)
               {
                  mostRecentEx = enfe;
                   proxy.Abort();
                   //  delay (backoff) and retry 
                   Thread.Sleep(1000 * (i + 1)); 
               }
    
               // The following exception that is thrown when a server is too busy to accept a message.
               catch (ServerTooBusyException stbe)
               {
                  mostRecentEx = stbe;
                   proxy.Abort();
                   //  delay (backoff) and retry 
                   Thread.Sleep(1000 * (i + 1)); 
               }
        
               catch(Exception )
               {
                    // rethrow any other exception not defined here
                    // You may want to define a custom Exception class to pass information such as failure count, and failure type
                    proxy.Abort();
                    throw ;  
               }
           }
           if (mostRecentEx != null) 
           { 
               proxy.Abort();
               throw new Exception("WCF call failed after 5 retries.", mostRecentEx );
           }
        }
    }
