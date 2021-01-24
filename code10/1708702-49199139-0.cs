         if(user.UserName == "xxx@****.com")
         {
            var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new CrestfineContext()));
            var manager = new UserManager<User>(new UserStore<User>(new CrestfineContext()));
            
            rolemanager.Create(new IdentityRole { Name = "Admin" });
            manager.AddToRole(user.Id, "Admin");
         }
