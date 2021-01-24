    public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
    {
        actionExecutedContext.ActionContext.ControllerContext.Configuration.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        base.OnActionExecuted(actionExecutedContext);
    }
