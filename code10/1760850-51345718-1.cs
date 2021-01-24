    publilc interface IAuditableEntity
    {
        //helper interface. put it on the entities you want to trace.
        //todo: add some properties like 'modified'
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        WriteAutoData();
        return base.SaveChangesAsync(cancellationToken);
    }
    private void WriteAutoData()
    {
        foreach (var entry in ChangeTracker.Entries().OfType<IAuditableEntity>().Where(c =>
            c.State != EntityState.Detached &&
            c.State != EntityState.Unchanged))
        {
            if (entry.State == EntityState.Added)
                //created logic here
            else if (entry.State == EntityState.Modified)
                //modified logic here
            else if (entry.State == EntityState.Deleted)
                //deleted logic here
        }
    }
