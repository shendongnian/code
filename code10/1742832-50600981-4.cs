    protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
    {
        if (FormsAuthentication.CookiesSupported == true)
        {
            if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                try
                {
                    //let us take out the username now                
                    string username = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                    string roles = string.Empty;
    
                    using (userDbEntities entities = new userDbEntities())
                    {
                        User user = entities.Users.SingleOrDefault(u => u.username == username);
    
                        roles = user.Roles;
                    }
                    //let us extract the roles from our own custom cookie
                    
    
                    //Let us set the Pricipal with our user specific details
                    HttpContext.Current.User  = new System.Security.Principal.GenericPrincipal(
                      new System.Security.Principal.GenericIdentity(username, "Forms"), roles.Split(';'));
                }
                catch (Exception)
                {
                    //somehting went wrong
                }
            }
        }
    } 
