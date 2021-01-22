    public class Ping : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            context.Response.ContentType = "text/plain";
            context.Response.Write("OK");
        }
    
        public bool IsReusable
        {
            get { return true; }
        }
    }
