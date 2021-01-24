    public SiteRole()
    {
        // this field should be removed
        // _userService = DependencyResolver.Current.GetService<IUserService>();
    }
    // this property should be used instead of field
    private IUserService UserService 
    {
        get { DependencyResolver.Current.GetService<IUserService>(); }
    }
