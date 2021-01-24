    private void PopulateAuditTrailProperties()
    {
        var httpContextAccessor = this.GetService<IHttpContextAccessor>();
        var username = httpContextAccessor?.HttpContext.User.Identity.Name;
        foreach (var entry in ChangeTracker.Entries<IEntity>().Where(x => x.State == EntityState.Added))
        {
            entry.Entity.CreatedOn = DateTimeOffset.UtcNow;
            entry.Entity.CreatedBy = username;
        }
        foreach (var entry in ChangeTracker.Entries<IEntity>().Where(x => x.State == EntityState.Modified))
        {
             entry.Entity.ModifiedOn = DateTimeOffset.UtcNow;
             entry.Entity.ModifiedBy = username;
         }
    }
