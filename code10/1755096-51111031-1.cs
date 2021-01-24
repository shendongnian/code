    public override int SaveChanges()
    {
        try
        {
            return base.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            throw new UserFriendlyException("A message for the user");
        }
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        try
        {
            return await base.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            throw new UserFriendlyException("A message for the user");
        }
    }
