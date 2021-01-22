    protected void Page_PreInit(object sender, EventArgs e)
    {
      bool inDevMode = false;
      inDevMode = bool.Parse(ConfigurationManager.AppSettings["InDevMode"]); //Or you could use TryParse
      if(inDevMode)
      {
        // Fake authentication so I don't have to create a damn Login page just for this.
        System.Web.Security.FormsIdentity id = new FormsIdentity(new FormsAuthenticationTicket("dok", false, 30));
        string[] roles = { "a" };
        HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(id, roles);
      }
    }
