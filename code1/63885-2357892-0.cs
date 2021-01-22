    using System;
    using System.Web;
    using System.Web.Security;
    
    namespace CustomAuthRepurposingFormsAuth
    {
        public static class TicketHelper
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="userName"></param>
            /// <param name="userData">be mindful of the cookie size or you will be chasing ghosts</param>
            /// <param name="persistent"></param>
            /// <returns></returns>
            public static HttpCookie CreateAuthCookie(string userName, string userData, bool persistent)
            {
                DateTime issued = DateTime.Now;
                // formsAuth does not expose timeout!? have to hack around the
                // spoiled parts and keep moving..
                HttpCookie fooCookie = FormsAuthentication.GetAuthCookie("foo", true);
                int formsTimeout = Convert.ToInt32((fooCookie.Expires - DateTime.Now).TotalMinutes);
    
                DateTime expiration = DateTime.Now.AddMinutes(formsTimeout);
                string cookiePath = FormsAuthentication.FormsCookiePath;
    
                var ticket = new FormsAuthenticationTicket(0, userName, issued, expiration, true, userData, cookiePath);
                return CreateAuthCookie(ticket, expiration, persistent);
            }
    
            public static HttpCookie CreateAuthCookie(FormsAuthenticationTicket ticket, DateTime expiration, bool persistent)
            {
                string creamyFilling = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, creamyFilling)
                                 {
                                     Domain = FormsAuthentication.CookieDomain,
                                     Path = FormsAuthentication.FormsCookiePath
                                 };
                if (persistent)
                {
                    cookie.Expires = expiration;
                }
    
                return cookie;
            }
        }
