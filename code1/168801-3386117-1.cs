    if (Context.Session != null)
            {
                //Tested and the IsNewSession is more advanced then simply checking if 
                // a cookie is present, it does take into account a session timeout, because 
                // I tested a timeout and it did show as a new session
                if (Session.IsNewSession)
                {
                    // If it says it is a new session, but an existing cookie exists, then it must 
                    // have timed out (can't use the cookie collection because even on first 
                    // request it already contains the cookie (request and response
                    // seem to share the collection)
                    string cookieHeader = Request.Headers["Cookie"];
                    if ((null != cookieHeader) && (cookieHeader.IndexOf("ASP.NET_SessionId") >= 0))
                    {
                        Response.Redirect(Request.Url.ToString());
                    }
                }
            }
