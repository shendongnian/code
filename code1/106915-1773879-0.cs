    public override void OnAuthorization(AuthorizationContext filterContext)
    {
        if (...subscriptionExpired...)
        {
            filterContext.Cancel = true;
            filterContext.Result = new RedirectResult("/user/login");
        }
    }
