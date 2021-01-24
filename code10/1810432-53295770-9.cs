    private async Task<IList<string>> GetIdentityUserRolesAsync(HttpContext context, UserManager<IdentityUser> userManager)
    {
        var rolesCached= context.Items["__userRoles__"];
        if( rolesCached != null){
            return (IList<string>) rolesCached;
        }
        var identityUser = await userManager.GetUserAsync(context.User);
        var roles = await userManager.GetRolesAsync(identityUser);
        context.Items["__userRoles__"] = roles;
        return roles;
    }
