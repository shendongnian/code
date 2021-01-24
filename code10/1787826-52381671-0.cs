    public ActionResult ViewUser(string roleName)
    {       
        var UsersContext = new ApplicationDbContext();
        var usersInRole = new List<User>(); // assign instance before if conditions
        var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
    
        if (roleManager.RoleExists(roleName))
        {
            // change to FirstOrDefault is more recommended
            var role = roleManager.FindByName(roleName).Users.FirstOrDefault();
            if (role != null)
            {
                usersInRole = UsersContext.Users.Where(u => u.Roles.Select(r => r.RoleId).Contains(role.RoleId)).ToList();
            }
        }
    
        return View(usersInRole);
    }
