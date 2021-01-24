    var routeBuilder = new RouteBuilder(app, trackPackageRouteHandler);
    
    routeBuilder.MapGet("hello/{name}", context => {
        var name = context.GetRouteValue("name");
        return context.Response.WriteAsync($"Hi, {name}!"); });            
    
    var routes = routeBuilder.Build(); app.UseRouter(routes);
