    public class CustomRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            //do stuff
            string controller = RequestContext.RouteData.Values["controller"].ToString();
            string methodName =  RequestContext.RouteData.Values["action"].ToString();
            //do stuff
        }
    }
    public class RoutingHandler : UrlRoutingHandler
    {
         protected override void VerifyAndProcessRequest(IHttpHandler httpHandler, HttpContextBase httpContext)
        {
        }
    }
