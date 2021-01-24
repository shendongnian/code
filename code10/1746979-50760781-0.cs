    public sealed class Setting 
        {
           private static Lazy<Setting> lazy =
           new Lazy<Setting>(() => new Setting());
    
            public static Setting CacheInstance
            {
                get
                {
                    return lazy.Value;
                }
            }
    
            private Setting()
            {
            }
    
            public List<string> GetCentres(Request request)
            {
    
                return GetCentres(request);
            }
    
            private List<string> GetCentres(Request request)
            {
              //implementation
    
            }
    
        }
