    public MyContext(bool impersonate = true): base("name=MyContext")
    {
        if (impersonate)
        {
            var currentUsername = HttpContext.Current.GetOwinContext().Authentication.User?.Identity?.Name;
            if (!string.IsNullOrEmpty(currentUsername)){
                KerberosTokenCacher kerberosTokenCacher = new KerberosTokenCacher();
                KerberosReceiverSecurityToken token = kerberosTokenCacher.ReadFromCache(currentUsername);
                if (token != null)
                {
                    token.WindowsIdentity.Impersonate();
                }
                else
                {
                    // token has expired or cache has expired so you must log in again
                    HttpContext.Current.Response.Redirect("Login/Logoff");
                }
                        
            }
        }
    }
