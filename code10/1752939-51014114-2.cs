    public Task<IdentityUser> GetCurrentUserAsync(string accountId)
    {
        return context.Users
            .Where(x => x.Id == accountId)
            .SingleOrDefaultAsync();
    }
