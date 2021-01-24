    var user = db.Users.Include(x => x.Groups.Select(y => y.Roles))
                       .SingleOrDefault(u => u.InternetId == username);
    var groups = user.Groups.SelectMany(
                       g => g.Roles.Where(r => r.Asset.AssetName == application));
    
    var userRoles = Mapper.Map<List<RoleApi>>(groups);
