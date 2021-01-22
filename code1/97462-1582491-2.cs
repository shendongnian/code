    public static class CacheHelper
    {
        public static MyObject Get()
        {
            MyObject obj = HttpRuntime.Cache.Get("myobject") as MyObject;
            if (obj == null)
            {
                // Create the object to insert into the cache
                obj = CreateObjectByWhateverMeansNecessary();
                
                HttpRuntime.Cache.Insert("myobject", obj, null, DateTime.Now.AddMinutes(5), System.Web.Caching.Cache.NoSlidingExpiration);
            }
            return obj;
        }
    }
