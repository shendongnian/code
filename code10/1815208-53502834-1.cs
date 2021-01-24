    public override int SaveChanges()
    {
        try
        {
            return base.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new UserFriendlyException("Update Concurrency Happened");
        }
    }
    public override async Task<int> SaveChangesAsync()
    {
        try
        {
            return await base.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new UserFriendlyException("Update Concurrency Happened");
        }
    }
