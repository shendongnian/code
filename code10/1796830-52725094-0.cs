    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        var svc = filterContext.HttpContext.RequestServices;
        var memCache = svc.GetService<IMemoryCache>();
        //..etc
