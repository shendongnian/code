     protected override void OnException(ExceptionContext filterContext)
     {
        if (filterContext.Exception.GetType() == typeof(InvalidOperationException))
        {
            filterContext.Result = RedirectToAction("Index", "Home");
            filterContext.ExceptionHandled = true;
        }
        base.OnException(filterContext);
     }
