    protected void Application_Start()
            {
                AreaRegistration.RegisterAllAreas();
                GlobalConfiguration.Configure(WebApiConfig.Register);
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);
    
               // Add this
                PostAuthenticateRequest += Application_PostAuthenticateRequest;
            }
    
    
    
      protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
            {
                if (User.Identity.IsAuthenticated)
                {
                    //Do stuff here
                    HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
    
                    if (authCookie != null)
                    {
                        FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
    
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
    
                        var serializeModel = serializer.Deserialize<CustomPrincipalSerializeModel>(authTicket.UserData);
    
                        var roles = new List<string>() { serializeModel.RoleNameCode }; // English name of role like 'Administrator'
    
                        var newUser = new CustomPrincipal(User.Identity, roles.ToArray())
                        {
                            Id = serializeModel.Id,
                            FirstName = serializeModel.FirstName,
                            LastName = serializeModel.LastName,
                            MiddleName = serializeModel.MiddleName,
                            RoleName = serializeModel.RoleName // Custom name of role i.e. in Spanish I use it to display for user
                        };
    
         
                          HttpContext.Current.User = newUser;
                    }
                }
    
               
            }
