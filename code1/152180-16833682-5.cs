    public static Route MapServiceRoute(this RouteCollection routes, string routeName, string url, string virtualPath)
    {
        if( routes == null )
            throw new ArgumentNullException("routes");
        Route route = new Route(url, new RouteValueDictionary() { { "controller", null }, { "action", null } }, new ServiceRouteHandler(virtualPath));
        routes.Add(routeName, route);
        return route;
    }
