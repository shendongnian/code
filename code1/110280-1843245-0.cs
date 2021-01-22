    public class MyClass
    {
            private static object _listCacheMonitor = new object();
            private static List<Entry> _listCache = null; 
            protected static List<Entry> ListCache
            {
                get
                {
                    lock (_listCacheMonitor) {    
                        if (_listCache == null)
                        {
                            _listCache = new List<Entry>();
                            //Add items to the list _listCache from XML file
                        }
                    }
                    return _listCache;
                }
            }
            //....Other methods that work with the list
    }
