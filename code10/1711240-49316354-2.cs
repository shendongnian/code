    public class SessionHander : 
        System.Web.Http.WebHost.HttpControllerHandler, 
        System.Web.SessionState.IRequiresSessionState
    {
        public SessionHander(RouteData routeData) : base(routeData)
        { }
    }
    public class SeesionRouterHanlder : 
        System.Web.Http.WebHost.HttpControllerRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new SessionHander(requestContext.RouteData);
        }
    }
