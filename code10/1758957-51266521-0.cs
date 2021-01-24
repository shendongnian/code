    // provide a value to use if the first result is null, using a null coalescer
    IsSelected = user.ActionPermissions.Any(p => p.PermissionActionId == a.Id)
                 || (user.Group?.GroupActionPermissions.Any(z => z.PermissionActionId == a.Id) ?? false)
    // if it's supported in your situation, you may be able to use HasValue
    IsSelected = user.ActionPermissions.Any(p => p.PermissionActionId == a.Id)
                 || (user.Group.HasValue && user.Group.GroupActionPermissions.Any(z => z.PermissionActionId == a.Id))
