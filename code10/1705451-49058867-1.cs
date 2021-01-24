    public class ValidateAccessAttribute2 : ActionFilterAttribute
    {
        private readonly FunctionalArea _area;
        public ValidateAccessAttribute2(FunctionalArea area)
        {
            _area = area;
        }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            if (!actionContext.Request.Headers.Contains(AuthorizationHeaders.UserNameHeader))
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                return;
            }
            var userName = actionContext.Request.Headers.GetValues("UserNameHeader").First();
            if (!UserCanAccessArea(userName, _area))
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                return;
            }
        }
    }
        [ValidateAccess2(FunctionalArea.AccessToGenericStuff)]
        public async Task<IHttpActionResult> Stuff()
