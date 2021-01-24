        using(ApplicationDbContext db=new ApplicationDbContext())
        {
              var users = (from user in db.Users
                           from roles in user.Roles
                           join role in db.Roles
                           on roles.RoleId equals role.Id 
                           select new
                           {
                               user.UserName, 
                               role.Name
                           }).ToList(); 
        }
