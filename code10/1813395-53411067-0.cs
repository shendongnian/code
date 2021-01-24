    public class CustomAuthorization : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            AuthenticationHeaderValue authenticationHeaderValue = actionContext.Request.Headers.Authorization;
            var userNamePasswordString = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationHeaderValue.Parameter));
        }
    }
