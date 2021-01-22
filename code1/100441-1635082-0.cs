    public static RouteData GetRouteValues(IRouteRegistrant registrant, string url)
    {
          var routes = new RouteCollection();
          registrant.Register(routes);
          var context = new FakeHttpContext(url);
          return routes.GetRouteData(context);
    }
