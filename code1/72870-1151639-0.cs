    public class AuthorisationModule : IHttpModule
    {
        public void Init( HttpApplication context )
        {
            context.AuthorizeRequest += AuthorizeRequest;
        }
        private void AuthorizeRequest(object sender, EventArgs e)
        {
            var currentUser = HttpContext.Current.User;
            if( !currentUser.IsAuthenticated() )
            {
                return;
            }
            var roles = new List<string>();
            // Add roles here using whatever logic is required
            var principal = new GenericPrincipal( currentUser.Identity, roles.ToArray() );
            HttpContext.Current.User = principal;
        }
        public void Dispose()
        {
            if(HttpContext.Current == null )
            {
                return;
            }
            if(HttpContext.Current.ApplicationInstance == null)
            {
                return;
            }
            HttpContext.Current.ApplicationInstance.AuthorizeRequest -= AuthorizeRequest;
        }
    }
