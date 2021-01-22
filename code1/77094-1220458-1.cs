    public override void OnActionExecuted(ActionExecutedContext filterContext)
    {
        GetType().GetMethod("DoActionExecuted",
                            BindingFlags.NonPublic | BindingFlags.Instance)
                 .MakeGenericMethod(ListType)
                 .Invoke(this, new[] {filterContext});
    }
