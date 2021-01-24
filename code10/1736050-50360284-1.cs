    public class CustomAuthFilter : IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var header = filterContext.RequestContext.HttpContext.Request.Headers["Authorization"];
            if (!Authenticate(header))
                filterContext.Result = new HttpUnauthorizedResult();
        }
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
           filterContext.Result = new RedirectResult(@"https:\\foo\YourLoginPage");
        }
        private bool Authenticate(string rawAuthorizationHeader)
        {
            try
            {
                if (rawAuthorizationHeader != null)
                {
                    var authHeader = AuthenticationHeaderValue.Parse(rawAuthorizationHeader);
                    if (authHeader != null
                        && authHeader.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase)
                        && authHeader.Parameter != null)
                    {
                        var credentialPair = Encoding.ASCII.GetString(Convert.FromBase64String(authHeader.Parameter));
                        var credentials = credentialPair.Split(new[] { ":" }, StringSplitOptions.None);
                        var userName = credentials[0];
                        var plainTextPassword = credentials[1];
                        return SomeAuthenticator.Authenticate(userName, plainTextPassword);
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
