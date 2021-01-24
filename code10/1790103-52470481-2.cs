    var allRoles = _roleMaganer.GetAllRoles();
    var users = (from u in db.Users
            join m in db.Memberships on u.UserId equals m.UserId
            select new 
            {
               m.Email,
               u.UserName,
               u.UserId,
               m.IsLockedOut,
               Roles = allRoles.FirstOrDefault(x=>x.UserName == u.UserName) //doesn't work   
             }).ToList();
