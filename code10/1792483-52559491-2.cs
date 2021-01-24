    protected override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (UserContext == null || UserContext.Id.Equals(Guid.Empty))
                {
                    if (filterContext.Controller.GetType()     == typeof(AccountController) || filterContext.Controller.GetType() == typeof(HomeController)) return;
                    filterContext.Result                       = new RedirectResult("/Home/Index");
                    return;
                }
    }
