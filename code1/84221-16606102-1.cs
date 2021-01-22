    public void OnActionExecuting(ActionExecutingContext filterContext)
    {
        if (filterContext.ActionDescriptor.IsDefined(typeof(AnotherActionAttribute), false))
        {
            // do what you want to do
        }
    }
