    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    {
        // Returns HTTP 401 by default - see HttpUnauthorizedResult.cs.
        filterContext.Result = new RedirectToRouteResult(
        new RouteValueDictionary 
        {
            { "action", "ActionName" },
            { "controller", "ControllerName" },
            { "parameterName", "parameterValue" }
        });
    }
