     public override void OnActionExecuting(ActionExecutingContext filterContext)
     {
        ...
        if (needToRedirect)
        {
           ...
           filterContext.Result = new RedirectResult(url);
           return;
        }
        ...
     }
