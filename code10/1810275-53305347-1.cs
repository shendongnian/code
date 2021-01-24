    class CustomAuthorizeAttribute : AuthorizationFilterAttribute
    {
        public override async Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var content = await actionContext.Request.Content.ReadAsFormDataAsync(cancellationToken);
        }
    }
