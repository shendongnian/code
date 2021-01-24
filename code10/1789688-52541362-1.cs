    public static void RegisterRoutes(RouteCollection routes)
    {
        // the Ng controller is published directly onto the root,
        // the * before id makes sure that everything after the action name
        // is kept as-is
        routes.MapRoute("Ng",
            "{action}/{*id}",
            new {controller = "Ng", id = UrlParameter.Optional},
            new {action = GetUiConstraint()}
        );
    
        // this route allows the mapping of the default site route
        routes.MapRoute(
            "Default",
            "{controller}/{action}/{*id}",
            new { controller = "Ng", action = "Index", id = UrlParameter.Optional }
        );
    }
    
    /// <summary> The Ui constraint is to be used as a constraint for the Ng route.
    /// It is an expression of the form "^(app1)|(app2)$", with one branch for
    /// each possible SPA. </summary>
    /// <returns></returns>
    public static string GetUiConstraint()
    {
        // If you don't need this level of indirection, just
        // swap this function with the result.
        // return "^(TheApp)|(AnotherSPA)$";
    
        var uiActions = new ReflectedControllerDescriptor(typeof(NgController))
            .GetCanonicalActions()
            .Select(x => x.ActionName.ToLowerInvariant())
            .Where(x => x != "index")
            .Select(x => "(" + x + ")");
    
        return string.Concat("^", string.Join("|", uiActions), "$");
    }
