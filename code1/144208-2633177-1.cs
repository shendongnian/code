        private readonly AuthenticationServiceClient service = new AuthenticationServiceClient();
        
        public void SignIn(string userName, string password, bool createPersistentCookie)
        {
            using (new OperationContextScope(service.InnerChannel))
            {
                // login
                service.Login(userName, password, String.Empty, createPersistentCookie);
  
                // Get the response header
                var responseMessageProperty = (HttpResponseMessageProperty)
                    OperationContext.Current.IncomingMessageProperties[HttpResponseMessageProperty.Name];
                string encryptedCookie = responseMessageProperty.Headers.Get("Set-Cookie");
                // parse header to cookie object
                var cookieJar = new CookieContainer();
                cookieJar.SetCookies(new Uri("http://localhost:1062/"), encryptedCookie);
                Cookie cookie = cookieJar.GetCookies(new Uri("http://localhost:1062/"))[0];
                
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
                if (null != ticket)
                {
                    //string[] roles = RoleManager.GetRolesFromString(ticket.UserData); 
                    HttpContext.Current.User = new GenericPrincipal(new FormsIdentity(ticket), null);
                    FormsAuthentication.SetAuthCookie(HttpContext.Current.User.Identity.Name, createPersistentCookie);
                }
            }
        }
