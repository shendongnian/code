    var user = _userRepository
                    .FirstOrDefaultAsync(us => us.Email == email); 
    var userPermissions = 
               user.UserRoles
                   .First()
                   .Role
                   .RolePermissions
                   .Select(rp => rp.Permission)
                   .ToList();
