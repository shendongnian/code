            if (Context.Session != null)
            {
                if (Context.Session.IsNewSession)
                {
                    string sCookieHeader = Request.Headers["Cookie"];
                    if ((null != sCookieHeader) && (sCookieHeader.IndexOf("ASP.NET_SessionId") >= 0))
                    {
                        if (Request.IsAuthenticated)
                        {
                            FormsAuthentication.SignOut();
                        }
                        Response.Redirect("Error Page");
                    }
                }
            }
