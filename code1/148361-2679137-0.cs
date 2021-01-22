        /// <summary>
        /// Redirect Route Handler
        /// </summary>
        public class RedirectRouteHandler : IRouteHandler
        {
    
        private string newUrl;
    
        public RedirectRouteHandler(string newUrl)
        {
            this.newUrl = newUrl;
        }
    
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new RedirectHandler(newUrl);
        }
    }
    
    /// <summary>
    /// <para>Redirecting MVC handler</para>
    /// </summary>
    public class RedirectHandler : IHttpHandler
    {
        private string newUrl;
    
        public RedirectHandler(string newUrl)
        {
            this.newUrl = newUrl;
        }
    
        public bool IsReusable
        {
            get { return true; }
        }
    
        public void ProcessRequest(HttpContext httpContext)
        {
            httpContext.Response.Status = "301 Moved Permanently";
            httpContext.Response.StatusCode = 301;
            httpContext.Response.AppendHeader("Location", newUrl);
            return;
        }
    }
