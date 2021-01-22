     public IPrincipal User {
                get {
                    return HttpContext == null ? null : HttpContext.User;
                }
            }
...
 
    public HttpContextBase HttpContext {
            get {
                return ControllerContext == null ? null : ControllerContext.HttpContext;
            }
        }
