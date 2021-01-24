    public override void OnAuthorization(HttpActionContext actionContext) {
        var resolver = actionContext.ActionContext.RequestContext.Configuration.DependencyResolver;
        var _permissions = (IPermissions)resolver.GetService(typeof(IPermissions));
        var perm = _permissions.hasPermission();
        //...
    }
