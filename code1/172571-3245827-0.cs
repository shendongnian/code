    public class ExampleRoute : RouteBase
    {
    
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var url = httpContext.Request.Headers["HOST"];
            var index = url.IndexOf(".");
    
            if (index < 0)
                return null;
    
            var subDomain = url.Substring(0, index);
    
                var routeData = new RouteData(this, new MvcRouteHandler());
                routeData.Values.Add("controller", subdomain); //attempts to go to controller action of the subdomain
                routeData.Values.Add("action", "Index"); //Goes to the Index action on the User2Controller
    
                return routeData;
        }
    
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            //Implement your formating Url formating here
            return null;
        }
    }
