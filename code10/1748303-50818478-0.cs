    namespace SmithWcfService 
    {
        [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)] 
        public class SmithWcfService : ISmithWcfService 
        {
            private Func<string, int> callback;
    
            public SmithWcfService(Func<string, int> callback)
            {
                this.callback = callback;
            }
    
            public void SendRequest() 
            {
                //Ok, now I need to call Windows service application:
                var output = this.callback("input");
            }
        }
    }
