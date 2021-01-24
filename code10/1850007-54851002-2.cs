    public class MyCustomAuthorizeAttribute: AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authorized = base.AuthorizeCore(httpContext);
            bool isExceptionalCase = GetIfExceptional();//Assuming here where you look for some other condition other than user is authorized
            if (!isExceptionalCase && !authorized)
            {
                // The user is not authorized => no need to go any further
                return false;
            }
           
            return true;
        }
    }
