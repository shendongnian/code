    using System;
    using System.Configuration;
    
    namespace MyApplication
    {
    
        public sealed class MyApplicationConfiguration
        {
        
            public int NumberOfConnectionAttempts {get; private set;}
            public string ServerName {get; private set;}
            
            public MyApplicationConfiguration()
            {
                NumberOfConnectionAttempts = Convert.ToInt32(ConfigurationManager.AppSettings["ConnectionAtttempts"];
                ServerName = ConfigurationManager.AppSettings["ServerName"];
            }
        }
    }
