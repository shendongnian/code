    static void GrantPermission(this MyDbContext dbContext, User user, string permissionName)
    {
        // TODO: check input parameters
        var permissionToGrant = dbContext.Permissions
            .Where(permission => permission.Name == permissionName)
            .FirstOrDefault();
        // TODO: decide what to do if not found
        user.Permissions.Add(permissionToGrant);
        var userToChange = dbContext.Users
    }
 
