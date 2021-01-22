    using (RouteTable.Routes.GetWriteLock())
    {
        Route newRoute = new Route("{action}/{id}", new ReportRouteHandler());
        RouteTable.Routes.Add(newRoute);
    }
