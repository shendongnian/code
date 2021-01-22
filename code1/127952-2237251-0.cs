        private static Object lock_Instance = new Object ();
        public static UserBlogSettings Instance 
        { 
            get 
            { 
                string cacheKey = "UserBlogSettings-" + HttpContext.Current.Session["userOrgName"].ToString(); 
                UserBlogSettings cacheItem = HttpRuntime.Cache[cacheKey] as UserBlogSettings;
                if (cacheItem == null) 
                {
                    lock (lock_Instance)
                    {
                        // need to check again in case another thread got in here too
                        cacheItem = HttpRuntime.Cache[cacheKey] as UserBlogSettings;
                        if (cacheItem == null)
                        {
                            cacheItem = new UserBlogSettings();
                            HttpRuntime.Cache.Insert(cacheKey, cacheItem, null, 
                                DateTime.Now.AddMinutes(1), Cache.NoSlidingExpiration);
                        }
                    }
                } 
                return cacheItem; 
            } 
        } 
