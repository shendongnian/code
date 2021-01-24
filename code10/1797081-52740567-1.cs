    public override void OnAuthorization(HttpActionContext actionContext) {
        var resolver = actionContext.RequestContext.Configuration.DependencyResolver;
        var _permissions = (IPermissions)resolver.GetService(typeof(IPermissions));
        var perm = _permissions.hasPermission();
        //...
    }
