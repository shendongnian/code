    private static bool routesRegistered = false;
    protected void Application_BeginRequest(object sender, EventArgs e)
    {
      if (!routesRegistered)
      {
        Application.Lock();
        if (!routesRegistered) RouteManager.RegisterRoutes(RouteTable.Routes);
        routesRegistered = true;
        Application.UnLock();
      }
    }
