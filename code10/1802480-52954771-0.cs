    public override int SaveChanges()
    {
        foreach (var entityEntry in ChangeTracker.Entries()) // Iterate all made changes
        {
            if (entityEntry.Entity is Order order)
            {
                if (entityEntry.State == EntityState.Added) // If you want to update TenantId when Order is added
                {
                    order.TenantId = _tenantProvider.GetTenantId();
                }
                else if (entityEntry.State == EntityState.Modified) // If you want to update TenantId when Order is modified
                {
                    order.TenantId = _tenantProvider.GetTenantId();
                }
            }
        }
        return base.SaveChanges();
    }
