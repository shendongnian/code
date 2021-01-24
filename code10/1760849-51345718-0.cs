    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        WriteAutoData();
        return base.SaveChangesAsync(cancellationToken);
    }
    private void WriteAutoData()
    {
        foreach (var entry in ChangeTracker.Entries().Where(c =>
            c.State != EntityState.Detached &&
            c.State != EntityState.Unchanged))
        {
            //use some interface, it will help you
            var audit = entry.Entity as IAuditableEntity;
            if (audit == null)
                continue;
            if (entry.State == EntityState.Added)
                //created logic here
            else if (entry.State == EntityState.Modified)
                //modified logic here
            else if (entry.State == EntityState.Deleted)
                //deleted logic here
        }
    }
