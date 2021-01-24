    public async Task<IdentityResult> CreateRoleAsync(ApplicationRole applicationRole)
    {
        IdentityResult result = await userRole.CreateAsync(applicationRole);
        return result;
    }
