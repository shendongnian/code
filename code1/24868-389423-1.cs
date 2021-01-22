    <code>
    <%@ Application Language="C#" %>
    
    <script runat="server">
        
        private const string DeliveryPageUrl = "http://put any test url of your application";
    
        private const string DummyCacheItemKey = "Any hard coded value";  // you can put any name here DummyCacheItemKey = "gigigagagugu";
    
        void Application_Start(object sender, EventArgs e) 
        {
            // Code that runs on application startup
            RegisterCacheEntry();
        }
    
        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            // If the dummy page is hit, then it means we want to add another item
            // in cache
            if (HttpContext.Current.Request.Url.ToString() == DeliveryPageUrl)
            {
                // Add the item in cache and when succesful, do the work.
                RegisterCacheEntry();
            }
        }
        /// <summary>
        /// Register a cache entry which expires in 60 minute and gives us a callback.
        /// </summary>
        /// <returns></returns>
        private void RegisterCacheEntry()
        {
            // Prevent duplicate key addition
            if (null != HttpContext.Current.Cache[DummyCacheItemKey]) return;
    
            HttpContext.Current.Cache.Add(DummyCacheItemKey, "Test", null, DateTime.MaxValue,
                                            TimeSpan.FromMinutes(60), CacheItemPriority.NotRemovable,
                                            new CacheItemRemovedCallback(CacheItemRemovedCallback));
        }
        /// <summary>
        /// Callback method which gets invoked whenever the cache entry expires.
        /// We can do our "service" works here.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="reason"></param>
        public void CacheItemRemovedCallback(string key, object value, CacheItemRemovedReason reason)
        {
            // We need to register another cache item which will expire again in one
            // minute. However, as this callback occurs without any HttpContext, we do not
            // have access to HttpContext and thus cannot access the Cache object. The
            // only way we can access HttpContext is when a request is being processed which
            // means a webpage is hit. So, we need to simulate a web page hit and then 
            // add the cache item.
            HitPage();
        }
    
        /// <summary>
        /// Hits a local webpage in order to add another expiring item in cache
        /// </summary>
        private void HitPage()
        {
            System.Net.WebClient client = new System.Net.WebClient();
            client.DownloadData(DeliveryPageUrl);
        }
        void Application_End(object sender, EventArgs e) 
        {
            //  Code that runs on application shutdown
    
        }
            
        void Application_Error(object sender, EventArgs e) 
        { 
            // Code that runs when an unhandled error occurs
    
        }
    
        void Session_Start(object sender, EventArgs e) 
        {
            // Code that runs when a new session is started
    
        }
    
        void Session_End(object sender, EventArgs e) 
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.
    
        }
           
    </script>
    
       </code>
