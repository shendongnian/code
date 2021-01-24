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
            //you cannot have two methos with same name and same parameter that 
            //is also issue 
            //private List<string> GetCentres(Request request)
            //{
              //implementation
            //}
    
        }
