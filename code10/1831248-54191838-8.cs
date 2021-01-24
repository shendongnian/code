    private readonly IHttpContextAccessor accessor;
    public MyDependent(IHttpContextAccessor accessor) {
        this.accessor = accessor;
    }
    
    public void SomeMethodAccessedInAnAction() {
        var context = access.HttpContext; // HttpContextBase
        var session = context.Session; // HttpSessionStateBase
        var server = context.Server; // HttpServerUtilityBase
        var user = context.User; // IPrincipal
        //...
    }
