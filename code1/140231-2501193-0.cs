    public class ConfigurationStore
    {
        private static ConfigurationStore _instance = null;
        
        public static ConfigurationStore Instance {
            get {
    	    if(_instance == null)
    	    {
    	        _instance = new ConfigurationStore();
    	    }
    	    
    	    return _instance;
            }
        }
        
        public string GetValue(string key)
        {
            ....
        }
        
        public Object GetObject(string key)
        {
            ...
        }
    }
