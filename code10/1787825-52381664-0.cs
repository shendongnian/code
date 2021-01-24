    public ActionResult ViewUser(string roleName)
        {       
            var UsersContext = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            if (roleManager.RoleExists(roleName))
            {
                var role = roleManager.FindByName(roleName).Users.First();
                var usersInRole = UsersContext.Users.Where(u => u.Roles.Select(r => r.RoleId).Contains(role.RoleId)).ToList();
                return View(usersInRole);
            }
            else
            {
                return View(new List<Users>());
            }
    
        }
