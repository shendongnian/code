    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
        var cookies = context.HttpContext.Request.Cookies;
        var db = context.HttpContext.RequestServices.GetRequiredService<MVCProContext>();
        base.OnActionExecuting(context);
    }
