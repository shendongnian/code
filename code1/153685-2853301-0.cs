        private static void RegisterRoutes()
        {
            Route currRoute = new Route("{resource}.axd/{*pathInfo}", 
                                        new StopRoutingHandler());
            RouteTable.Routes.Add( "IgnoreHandlers", currRoute);
            currRoute = new Route("{urlname}",
                                new EPCRouteHandler("~/Default.aspx"));
            currRoute.Defaults = new RouteValueDictionary {{"urlname", "index.html"}};
            RouteTable.Routes.Add( "Default", currRoute);
        }
