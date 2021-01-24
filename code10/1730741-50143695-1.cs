     using (MyDb db = new MyDB()){
       Permission_To_Role ptr = new Permission_To_Role();
       ptr.PermissionId = 5;
       ptr.RoleId = 8;
       ptr.GrantedById = Session.CurrentUser.Id;
    
       db.Permission_To_Role.Add(ptr);
       db.SaveChanges();
    }
