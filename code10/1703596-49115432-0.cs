    List<ApplicationUser> usersInRole = new List<ApplicationUser>();
    foreach (var role in roleManager.Roles)
    {
        usersInRole.AddRange(await userManager.GetUsersInRoleAsync(role.Name));
    }
