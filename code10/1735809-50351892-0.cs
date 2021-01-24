    public class Global
    {
        private static CacheObject _cache;
        public static CacheObject cacheObject
        {
            get
            {
                if(_cache == null)
                {
                    InitializeCacheObject();
                }
                return _cache;
            }
            set
            {
                _cache=Value;
            }
        }
        public void InitializeCacheObject()
        {
            //get your data from db
            CacheObject = db.getData();
        }
    }
