    public ViewResult Index()
    {
        var rolesWithUsers = RoleManager.Roles.Include(r => r.Users).ToList();
    
        return View(rolesWithUsers);
    }
