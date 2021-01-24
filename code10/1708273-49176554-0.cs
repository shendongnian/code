    public async Task AddAsync(ApplicationUser user)
    {
        // need to await this one
        await _context.ApplicationUser.AddAsync(user);
        await _context.SaveChangesAsync();
    }
    public async Task AddToRoleAsync(ApplicationUser user, string roleName)
    {
        // same story
        await _userManager.AddToRoleAsync(user, roleName);
        await _context.SaveChangesAsync();
    }
    public async Task RemoveFromRoleAsync(ApplicationUser user, string roleName)
    {
        // same story
        await _userManager.RemoveFromRoleAsync(user, roleName);
        await _context.SaveChangesAsync();
    }
