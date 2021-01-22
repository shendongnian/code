    // create the LINQ-to-SQL Data context
    UsersAndRolesDataContext dc = new UsersAndRolesDataContext();
        
    // create new instace of "UserTbl" object
    UserTbl newUser = new UserTbl();
    newUser.UserID = "newuser";
    newUser.Name = "Some NewUser";
    newUser.EMail = "newuser@somewhere.org";
    newUser.Password = "TopSecret";
        
    // add new user to the table of users in the data context
    dc.UserTbls.InsertOnSubmit(newUser);
        
    // create new instance of a role
    RolesTbl newRole = new RolesTbl();
    newRole.RoleId = "ADMIN";
    newRole.RoleName = "Administrators";
    newRole.Description = "User with administrative rights";
        
    // add new role into LINQ-to-SQL Data context
    dc.RolesTbls.InsertOnSubmit(newRole);
        
    // write out all changes back to database
    dc.SubmitChanges();
