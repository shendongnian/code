    private IEnumerable<String> GetIdentityUserRoles()
    {
        IHttpContextAccessor contextAccessor = this.ServiceProvider.GetRequiredService<IHttpContextAccessor>();
        HttpContext context = contextAccessor.HttpContext;
        ClaimsPrincipal user = context.User;
        Object rolesCached = context.Items["__userRoles__"];
        if (rolesCached != null)
        {
            return (List<String>)rolesCached;
        }
        var roles = ((ClaimsIdentity)user.Identity).Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
        context.Items["__userRoles__"] = roles;
        return roles;
    }
