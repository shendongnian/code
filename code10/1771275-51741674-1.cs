    static void GrantPermission(this MyDbContext dbContext, User user, int permissionId)
    {
        // TODO: check input parameters
        var permissionToGrant = dbContext.Permissions
            .Where(permission => permission.Id == permissionId)
            .FirstOrDefault();
        // TODO: decide what to do if not found
        user.Permissions.Add(permissionToGrant);
        var userToChange = dbContext.Users
    }
    static void GrantPermission(this MyDbContext dbContext, Permission permission, int userId)
    {
         // TODO: check input parameters
         var userToGrantPermission = dbContext.Users
             .Where(user => user.Id == userId)
             .FirstToDefault();
          // TODO: decide what to do if not found
          permission.Users.Add(userToGrantPermission);
    }
