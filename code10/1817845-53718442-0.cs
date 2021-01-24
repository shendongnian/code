    public class AuthorizeTokenAttribute : System.Web.Http.AuthorizeAttribute
    {
          public override void OnAuthorization(HttpActionContext actionContext)
           {
              SetUserContext(actionContext.Request.GetOwinContext()
           }
    
        private bool SetUserIdentity(IOwinContext context)
        {
            AuthenticationTicket authenticationTicket = 
            Startup.OAuthBearerAuthenticationOptions.AccessTokenFormat.Unprotect(token);
        
            context.Authentication.User = new System.Security.Claims.ClaimsPrincipal();                      
            context.Authentication.User.AddIdentity(authenticationTicket.Identity);
        
        
        }
    }
