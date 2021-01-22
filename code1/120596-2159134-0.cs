    // Get the application's route collection.
    UrlRoutingModule module = new UrlRoutingModule();
    RouteCollection col = module.RouteCollection;
    
    // Fake a request to the supplied URL into the routing system
    string originalPath = this.HttpContext.Request.Path;
    this.HttpContext.RewritePath(urlToGetControllerFor);
    RouteData fakeRouteData = col.GetRouteData(this.HttpContext);
    // Get an instance of the controller that would handle this route
    string controllername = fakeRouteData.Values["controller"].ToString();
    var ctxt = new RequestContext(this.ControllerContext.HttpContext, fakeRouteData);
    IController controller = ControllerBuilder.Current.GetControllerFactory()
                              .CreateController(ctxt, controllername);
    
    // Reset our request path.
    this.HttpContext.RewritePath(originalPath.ToString());
