    [System.Diagnostics.DebuggerStepThrough]
    public override int SaveChanges()
    {
        var entities = ChangeTracker.Entries().Where(entry => entry.Entity is ITrackingEntities);
        foreach (var entityEntry in entities)
        {
            if (entityEntry.State == EntityState.Added)
            {
                ((ITrackingEntities) entityEntry.Entity).CreatedBy = _tokenService.LoginUserId;
                ((ITrackingEntities) entityEntry.Entity).CreatedDateUtc = DateTime.UtcNow;
            }
            ((ITrackingEntities) entityEntry.Entity).UpdatedBy = _tokenService.LoginUserId;
            ((ITrackingEntities) entityEntry.Entity).UpdatedDateUtc = DateTime.UtcNow;
        }
        return base.SaveChanges();
    }
