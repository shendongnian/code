    public override void OnAuthorization(AuthorizationContext filterContext)
    {
        ActionDescriptor action = filterContext.ActionDescriptor;
        bool IsUnsecured = action.GetCustomAttributes(
                             typeof(UnsecuredActionAttribute), true).Count() > 0;
    
        //If doesn't have UnsecuredActionAttribute - then do the authorization
        filterContext.HttpContext.SkipAuthorization = IsUnsecured;
    
        base.OnAuthorization(filterContext);
    }
