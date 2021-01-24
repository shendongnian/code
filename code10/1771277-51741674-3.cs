    static void GrantPermission(this MyDbContext dbContext, User user, string permissionName)
    {
        // TODO: check input parameters
        var permissionToDeny = dbContext.Permissions
            .Where(permission => permission.Name == permissionName)
            .FirstOrDefault();
        if (permissionToDeny != null)
        {
             user.Permissions.Remove(permissionToDeny);
        }
        // else: user does not have this Permission; do nothing
    }
    // TODO: if desired: add function with userId and permissionName
