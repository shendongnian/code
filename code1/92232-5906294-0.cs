    public class SessionExpireFilterAttribute : ActionFilterAttribute
        {
    
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                HttpContext ctx = HttpContext.Current;
    
                // check if session is supported
                if (ctx.Session != null)
                {
    
                    // check if a new session id was generated
                    if (ctx.Session.IsNewSession)
                    {
    
                        // If it says it is a new session, but an existing cookie exists, then it must
                        // have timed out
                        string sessionCookie = ctx.Request.Headers["Cookie"];
                        if ((null != sessionCookie) && (sessionCookie.IndexOf("ASP.NET_SessionId") >= 0))
                        {
                            string redirectOnSuccess = filterContext.HttpContext.Request.Url.PathAndQuery;
                            string redirectUrl = string.Format("?ReturnUrl={0}", redirectOnSuccess);
                            string loginUrl = FormsAuthentication.LoginUrl + redirectUrl;
                            if (ctx.Request.IsAuthenticated)
                            {
                                FormsAuthentication.SignOut();
                            }
                            RedirectResult rr = new RedirectResult(loginUrl);
                            filterContext.Result = rr;
                            //ctx.Response.Redirect("~/Home/Logon");
                            
                        }
                    }
                }
    
                base.OnActionExecuting(filterContext);
            }
        }
