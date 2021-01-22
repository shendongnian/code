    public IEnumerable<UserRole> GetUserRoles()
    {
        IEnumerable<UserRole> roles = this.ObjectContext.UserRole.Include("UserPermissionMembers.UserPermission");
        return roles;
    }
