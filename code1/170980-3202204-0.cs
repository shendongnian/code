    public override void OnActionExecuting(ActionExecutingContext filterContext) {
      if (Membership.GetUser() == null) {
           filterContext.Result = new RedirectResult("~/Logon");
       }
    }
