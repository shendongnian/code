    protected override void Initialize(RequestContext requestContext)
    {
        base.Initialize(requestContext);
        var list = requestContext.HttpContext.Cache[testMessageCacheAndViewDataKey];
        if (list == null) { ... }
    }
