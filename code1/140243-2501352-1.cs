    routes.Add(new Route("favicon.ico", new StaticFileRouteHandler("~/favicon.ico")));
    public class StaticFileRouteHandler : IRouteHandler
    {
        public string VirtualPath { get; set; }
        public StaticFileRouteHandler(string virtualPath)
        {
            VirtualPath = virtualPath;
        }
        public System.Web.IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            HttpContext.Current.RewritePath(VirtualPath);
            return new DefaultHttpHandler();
        }
    }
