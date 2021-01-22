    using(DatabaseEntities db = new DatabaseEntities())
    {
        //creates the user and add the properties except roles
        Users user = new Users();
        user.username = "Test";
        
        //get an existing role
        var role = db.Roles.SingleOrDefault(r => r.roleName == "User");
        
        //adds the userid and roleid in to userRoles
        user.Roles.Add(role);
        
        //saves it to the db
        db.SaveChanges();
    }
