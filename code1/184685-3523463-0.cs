    public class FacebookSession : IAPISession
    {
        private IAPISession currentSession;
    
        private FacebookSession()
        {
            currentSession = GetCurrentSession();
        }
    
        ...more code
    
        public FacebookSession GetCurrentSession()
        {
            // my logic is here...whatever that may be
        }
         ... more code
     }
