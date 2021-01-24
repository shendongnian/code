    protected UrlHelperBase(ActionContext actionContext)
    {
        if (actionContext == null)
        {
            throw new ArgumentNullException(nameof(actionContext));
        }
        ActionContext = actionContext;
        AmbientValues = actionContext.RouteData.Values;
        _routeValueDictionary = new RouteValueDictionary();
    }
