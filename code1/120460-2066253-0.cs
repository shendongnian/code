    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    sealed public class RedirectIfUserNotLoggedOnAttribute : ActionFilterAttribute
    {
    public override void OnActionExecuting (ActionExecutingContext filterContext)
      {
        if (!IsUserLoggedOn)
            {
              filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                                                                                          {
                                                                                            controller = "User",
                                                                                            action = "WarnLogOutAsJson",
                                                                                          }));
            }
    }
    }
