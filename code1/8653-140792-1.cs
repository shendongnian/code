    private bool IsValidSession()
        {
            bool isValidSession = true;
            if (Context.Session != null)
            {
                if (Session.IsNewSession)
                {
                    string cookieHeader = Request.Headers["Cookie"];
                    if ((null != cookieHeader) && (cookieHeader.IndexOf("ASP.NET_SessionId") >= 0))
                    {
                        isValidSession = false;
                        if (User.Identity.IsAuthenticated)
                            FormsAuthentication.SignOut();
                        FormsAuthentication.RedirectToLoginPage();
                    }
                }
            }
            return isValidSession;
        }
