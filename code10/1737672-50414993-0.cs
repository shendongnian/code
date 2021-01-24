    public class Client 
    {
        private static Client instance;
        
        public static Client Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Client();
                }
                return instance;
            }
        }
    
        string _firstname, _lastname, _address;
        //Public constructors and Properties would go here//
        // Make constructors Private! //
    }
