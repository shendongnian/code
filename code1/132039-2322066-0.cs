    public class Session
    {
        private static Dictionary<string, object> _instance = new Dictionary<string, object>();
        private Session()
        {            
        }
        public static Dictionary<string, object> Instance
        {
            get
            {
               if(_instance == null)
               {
                   _instance = new Dictionary<string, object>();
               }
                return _instance;
            }
        }
    }
