    using System;
    using System.Collections.Specialized;
    using System.Security.Principal;
    using System.Threading;
    using System.Web;
    using System.Web.Security;
    
    namespace SimpleRoles
    {
        public class Global : HttpApplication
        {
            private static readonly NameValueCollection Roles =
                new NameValueCollection(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {"administrator", "admins"},
                        // note, a user can be in more than one role
                        {"administrator", "codePoets"},
                    };
    
            protected void Application_AuthenticateRequest(object sender, EventArgs e)
            {
                HttpCookie cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                if (cookie != null)
                {
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
                    Context.User = Thread.CurrentPrincipal =
                                   new GenericPrincipal(Context.User.Identity, Roles.GetValues(ticket.Name));
                }
            }
        }
    }
