    void Application_Start(object sender, EventArgs e)
    {
        Route r = new Route("{Parameter}", new ExampleRouteHandler());
        Routes.Add(r);
    }
