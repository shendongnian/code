    //Finding the exclusive elements
    var onlyInRoles = roles.RolesWithRights.Except(role.RolesWithRights);
    //adding to role and delete from roles
    onlyInRoles.forEach(x => {
    role.RolesWithRights.Add(x);
    roles.RoleWIthRights.Remove(x);
    });
