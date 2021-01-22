     protected void Application_AuthenticateRequest(Object sender, EventArgs e)
            {
                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie != null)
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
    
                    User user;
                    Cache cache = HttpContext.Current.Cache;
                    using (HgDataContext hg = new HgDataContext())
                    {
                        user =  cache[authTicket.Name] as User;
                        if (user == null)
                        {
                           user = (from u in hg.Users where u.EmailAddress == authTicket.Name select u).Single();
                           cache[authTicket.Name] = user;
                        }
                    }
                    var principal = new HgPrincipal(user);
                    Context.User = principal;
                }
            }
