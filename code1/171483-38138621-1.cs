    void OnActionExecuting(ActionExecutingContext filterContext)
    {
       try
       {
          some condition ...
       }
       catch
       {
          if (filterContext.Controller.GetType() !=     typeof(AccountController))
          {
             filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Account" }, { "action", "Login" } });
          }
       }
    }
