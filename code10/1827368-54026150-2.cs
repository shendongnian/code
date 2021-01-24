    protected override void OnAuthorization(AuthorizationContext filterContext)
            {
                if (filterContext.HttpContext.User != null)
                {
                    if (filterContext.HttpContext.User.Identity.IsAuthenticated)
                    {
                        if (filterContext.HttpContext.User.Identity is FormsIdentity)
                        {
                            FormsIdentity id = (FormsIdentity)HttpContext.User.Identity;
                            FormsAuthenticationTicket ticket = id.Ticket;
                            string userData = ticket.UserData;
                            string[] roles = userData.Split(',');
                            HttpContext.User = new GenericPrincipal(HttpContext.User.Identity, roles);
                        }
                    }
                }
            }
