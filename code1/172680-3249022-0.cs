    var user = new User { UserId = 1 };
    var admin = new Privilege { PrivilegeId = 1 };
    user.Privileges.Add(admin);
    db.Users.Attach(user);
    user.Privileges.Remove(admin);
    db.SaveChanges();
