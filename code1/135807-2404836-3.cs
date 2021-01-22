    public class MySingleton
    {
        private static MySingleton _instance;    
    
        private MySingleton() { }
    
        public static MySingleton Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new MySingleton();
    
                return _instance;
            }
        }
    
        // Your properties can then be whatever you want
        public string Value { get; set; }
       
        public string Name { get; set; }
    }
