    public class CacheTest : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            TimeSpan expire = new TimeSpan(0, 0, 5, 0);
            DateTime now = DateTime.Now;
            context.Response.Cache.SetExpires(now.Add(expire));
            context.Response.Cache.SetMaxAge(expire);
            context.Response.Cache.SetCacheability(HttpCacheability.Server);
            context.Response.Cache.SetValidUntilExpires(true);
    
            context.Response.ContentType = "text/plain";
            context.Response.Write(DateTime.Now.ToString());
        }
    
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
