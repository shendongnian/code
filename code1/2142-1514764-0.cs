    protected void Application_Start()
    {
        WebFormViewEngine engine = new WebFormViewEngine();
        engine.ViewLocationFormats = new[] { "~/bin/Views/{1}/{0}.aspx", "~/Views/Shared/{0}.aspx" };
        engine.PartialViewLocationFormats = engine.ViewLocationFormats;
        ViewEngines.Engines.Clear();
        ViewEngines.Engines.Add(engine);
        RegisterRoutes(RouteTable.Routes);
    }
