    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        OnBeforeSaveChanges();
    
        var result = base.SaveChanges(acceptAllChangesOnSuccess);
    
        return result;
    }
    
    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
    {
        OnBeforeSaveChanges();
    
        var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    
        return result;
    }
    
    private void OnBeforeSaveChanges()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(p => p.State == EntityState.Added || p.State == EntityState.Modified || p.State == EntityState.Deleted)
            .ToList();
    
        foreach (var entry in entries)
        {
            foreach (var property in entry.Properties)
            {
                var originalValue = property.OriginalValue;
                var currentValue = property.CurrentValue;
            }
        }
    }
