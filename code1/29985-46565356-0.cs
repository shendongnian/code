        public override void OnAuthorization(AuthorizationContext actionContext)
        {
            if (AuthorizeCore((HttpContextBase)actionContext.HttpContext))
                return;
            HandleUnauthorizedRequest(actionContext);
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
                filterContext.Result = new HttpStatusCodeResult(403, "IP Access Denied");
        }
