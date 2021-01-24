    public interface ICacheManagerConfigFactory {
        ICacheManagerConfiguration CreateCacheManager();
    }
	
	public CacheManagerFactory:ICacheManagerConfigFactory {
	
	    private static ICacheManagerConfiguration _cache;
        private static object syncRoot = new Object();
		
        public ICacheManagerConfiguration CreateCacheManager() {
	
            if(_cache!=null) { return _cache; }	
            //locking to make sure that we only create 1 _cache object (thread-safe)
			lock(syncRoot) {
                //idiot-proofing our thread-safe code
                if(_cache!=null) { return _cache; }	
                //create _cache if it doesn't already exist
                var jss = new JsonSerializerSettings {
                    NullValueHandling = NullValueHandling.Ignore,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };	
                _cache= new CacheManager.Core.ConfigurationBuilder()
                   .WithJsonSerializer(serializationSettings: jss, deserializationSettings: jss)
			       ... etc ...
                   .Build();
            }
            return _cache;
        }
    }
