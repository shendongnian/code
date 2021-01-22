    protected override void OnException(ExceptionContext filterContext)
    {
        //InvalidOperationException is thrown if the path to the view
        // cannot be resolved by the viewengine
        if (filterContext.Exception is InvalidOperationException)
        {
            filterContext.ExceptionHandled = true;
            filterContext.Result = View("~/Views/Error/NotFound.aspx");
            filterContext.HttpContext.Response.StatusCode = 404;
        }
    
        base.OnException(filterContext);
    }
