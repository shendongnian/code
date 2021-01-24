    public class WebApiApplication : System.Web.HttpApplication
        {
            protected void Application_Start()
            {
                GlobalConfiguration.Configuration.Filters.Add(new CheckAuthorizationFilterAttribute());
                GlobalConfiguration.Configure(WebApiConfig.Register);
            }
        }
        public class CheckAuthorizationFilterAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(HttpActionContext actionContext)
            {
                var requestUri = actionContext.Request.RequestUri.AbsolutePath;
                if (requestUri == "/api/users/register")
                {
                    var isTokenValid = ValidateToken();
                    if (!isTokenValid)
                        actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    return;
                }
            }
    
            public bool ValidateToken() => false;
    
            public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
            {
    
            }
        }
