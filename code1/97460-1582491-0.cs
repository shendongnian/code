    public static class CacheHelper
    {
        public static MyObject Get()
        {
            MyObject obj = HttpRuntime.Cache.Get("myobject") as MyObject;
            if (obj == null)
            {
                // Create the object to insert into the cache
                obj = GetObject();
                
                HttpRuntime.Cache.Insert("myobject", obj, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(0, 5, 0));
            }
            return obj;
        }
    }
