    class CustomAuthorizeAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext context)
        {
            var authhash = context.Request.Headers.Authorization.Parameter;
        }
    }
