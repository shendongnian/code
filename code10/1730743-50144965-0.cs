    using (MyDb db = new MyDB()){
        Permission_to_Role ptr = new Permission_to_Role();
        ptr.PermissionId = permissionId;
        ptr.RoleId = r.Id;
        ptr.GrantedById = u.Id;
        ptr.GrantedAt = DateTime.Now;
    
        db.Permission_to_Role.Add(ptr);
        db.SaveChanges();
    }
