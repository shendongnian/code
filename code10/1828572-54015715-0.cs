    using(var context = new YourContextName())
    {
        var usersAndRoles = new List<UserRoleModel>(); // Adding this model just to have it in a nice list.
        var users = context.AspNetUsers;
    
        foreach(var user in users)
        {        
            foreach(var role in user.Roles)
            {
                usersAndRoles.Add(new UserRoleModel
                {
                    UserName = user.UserName,
                    RoleName = role.Name
                };
            }
        }
    }
