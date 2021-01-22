    using Newtonsoft.Json;
    using System.Web;
    using System.Web.Security;
    
    public class LoggedInUser
    {
        public string FirstName { get; set; } = null;
        public bool IsAdmin { get; set; } = false;
    }
    
    public static class Authentication
    {
        static void SignIn(
            HttpContextBase context,
            string emailAddress,
            bool rememberMe,
            LoggedInUser user = null)
        {
            var cookie = FormsAuthentication.GetAuthCookie(
                emailAddress.ToLower(),
                rememberMe);
            var oldTicket = FormsAuthentication.Decrypt(cookie.Value);
            var newTicket = new FormsAuthenticationTicket(
                oldTicket.Version,
                oldTicket.Name,
                oldTicket.IssueDate,
                oldTicket.Expiration,
                oldTicket.IsPersistent,
                JsonConvert.SerializeObject(user ?? new LoggedInUser()));
            
            cookie.Value = FormsAuthentication.Encrypt(newTicket);
    
            context.Response.Cookies.Add(cookie);
        }
    
        static void SignOut(HttpContextBase context)
        {
            FormsAuthentication.SignOut();
        }
    
        static LoggedInUser GetLoggedInUser()
        {
            if (HttpContext.Current.User?.Identity?.Name != null && HttpContext.Current.User?.Identity is FormsIdentity identity)
                return JsonConvert.DeserializeObject<LoggedInUser>(identity.Ticket.UserData);
    
            return new LoggedInUser();
        }
    }
