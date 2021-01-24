    var localRole = context.Set<TenantRole>().Local.FirstOrDefault(entry => entry.Id.Equals(stage.RoleId));
    if (localRole == null)
    {
        localRole = new TenantRole
        {
            Id = stage.RoleId,
        };
        Context.TenantRoles.Attach(localRole);
    }
    ...
    temp.Role = localRole;
