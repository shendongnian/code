    public sealed class APILookup
        {
            private static readonly APILookup _instance = new APILookup();
            private Dictionary<string, int> _lookup;
    
            private APILookup()
            {
                try
                {
                    _lookup = Utility.GetLookup();
                }
                catch { }
            }
    
            static APILookup()
            {            
            }
    
            public static APILookup Instance
            {
                get
                {
                    return _instance;
                }
            }
            public Dictionary<string, int> GetLookup()
            {
                return _lookup;
            }
    
        }
