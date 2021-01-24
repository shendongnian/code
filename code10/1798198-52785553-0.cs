    public sealed class UrlRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            var routeData = requestContext.RouteData.Values;
            var url = routeData["urlRouteHandler"] as string;
            // The class UrlHandler will have all the code for figuring things out
            var route = UrlHandler.GetRoute(url);
            routeData["url"] = route.Url;
            routeData["controller"] = route.Controller;
            routeData["action"] = route.Action;
            // other stuff to add
            // Now let MvcHandler process the request.
            return new MvcHandler(requestContext);
        }
    }
