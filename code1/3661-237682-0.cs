    using System;
    using System.Web;
    public class Global_asax : System.Web.HttpApplication
    {
        private void Application_BeginRequest(object sender, EventArgs e)
        {
            /* 
            Fix for the Flash Player Cookie bug in Non-IE browsers.
            Since Flash Player always sends the IE cookies even in FireFox
            we have to bypass the cookies by sending the values as part of the POST or GET
            and overwrite the cookies with the passed in values.
         
            The theory is that at this point (BeginRequest) the cookies have not been ready by
            the Session and Authentication logic and if we update the cookies here we'll get our
            Session and Authentication restored correctly
            */
            HttpRequest request = HttpContext.Current.Request;
            try
            {
                string sessionParamName = "ASPSESSID";
                string sessionCookieName = "ASP.NET_SESSIONID";
                string sessionValue = request.Form[sessionParamName] ?? request.QueryString[sessionParamName];
                if (sessionValue != null)
                {
                    UpdateCookie(sessionCookieName, sessionValue);
                }
            }
            catch (Exception ex)
            {
                // TODO: Add logging here.
            }
            try
            {
                string authParamName = "AUTHID";
                string authCookieName = FormsAuthentication.FormsCookieName;
                string authValue = request.Form[authParamName] ?? request.QueryString[authParamName];
                if (authValue != null)
                {
                    UpdateCookie(authCookieName, authValue);
                }
            }
            catch (Exception ex)
            {
                // TODO: Add logging here.
            }
        }
        private void UpdateCookie(string cookieName, string cookieValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(cookieName);
            if (cookie == null)
            {
                HttpCookie newCookie = new HttpCookie(cookieName, cookieValue);
                Response.Cookies.Add(newCookie);
            }
            else
            {
                cookie.Value = cookieValue;
                HttpContext.Current.Request.Cookies.Set(cookie);
            }
        }
    }
