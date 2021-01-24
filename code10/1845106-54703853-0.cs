    public ApplicationUserManager UserManager
    {
        get
        { 
            if(_userManager == null)
            {
                _userManager =  new ApplicationUserManager(new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(yourDbContext));
            }
            return _userManager;
        }
    }
