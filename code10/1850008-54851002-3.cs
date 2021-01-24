    public class MyCustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var authorized = base.IsAuthorized(actionContext);
            bool isExceptionalCase = GetIfExceptional();//Assuming here where you look for some other condition other than user is authorized
            if (!isExceptionalCase && !authorized)
            {
                // The user is not authorized => no need to go any further
                return false;
            }
            return true;
        }
    }
