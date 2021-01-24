    foreach (var role in roles)
    {
        tenantContext.TenantRoles.Add(new Role { Name = role.Name, CanBeDeleted = role.CanBeDeleted });
    }
    tenantContext.SaveChanges();
    foreach (var permission in permissions)
    {
        tenantContext.Permissions.Add(new Permission { Name = permission.Name });
    }
    tenantContext.SaveChanges();
    foreach (var map in permRoles)
    {
        tenantContext.RolePermissions.Add(new RolePermission
        {
            Permission = tenantContext.Permissions.FirstOrDefault(p => p.Name == map.Permission.Name),
            Role = tenantContext.TenantRoles.FirstOrDefault(r => r.Name == map.Role.Name)
        });
    }
    tenantContext.SaveChanges();
