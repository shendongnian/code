    public class SessionableControllerHandler : 
         System.Web.Http.WebHost.HttpControllerHandler, 
         System.Web.SessionState.IRequiresSessionState
    {
        public SessionableControllerHandler(RouteData routeData)
            : base(routeData)
        { }
    }
    public class SessionStateRouteHandler : System.Web.Http.WebHost.HttpControllerRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new SessionableControllerHandler(requestContext.RouteData);
        }
    }
