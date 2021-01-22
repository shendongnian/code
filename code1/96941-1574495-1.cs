    public ActionResult Menu
    {
      var links = new List<NavigationLink>
      {
        new NavigationLink
        {
          Text = "Home",
          Controller = "Home",
          Action = "Index"
        },
        new NavigationLink
        {
          Text = "Logout",
          Controller = "Authentication",
          Action = "Logout"
        }
      };
    
      return View( links );
    }
