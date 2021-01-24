    var user = new User()
    {
       Email = "jhon@gmail.com",                    
       RoleId = db.Roles.Single(r => r.RoleName = "Role_Name").Select(x=>x.RoleId)
     };
    
    db.Users.Add(user);
    db.SaveChanges();
