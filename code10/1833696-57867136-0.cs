    var controller = DependencyResolver.Current.GetService<ViewController>();
    RouteData route = new RouteData();
    route.Values.Add("action", "RedBluePDF");
    route.Values.Add("controller", "ApiController");
    ControllerContext newContext = new ControllerContext(new HttpContextWrapper(System.Web.HttpContext.Current), route, controller);
    
    controller.ControllerContext = newContext;
    controller.RedBluePDF(community, procedure);
