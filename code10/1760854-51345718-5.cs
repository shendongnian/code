    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        WriteAutoData();
        return base.SaveChangesAsync(cancellationToken);
    }
    //just a helper function
    private void WriteAutoData()
    {
        foreach (var entry in ChangeTracker.Entries().OfType<IAuditableEntity>().Where(c =>
            c.State != EntityState.Detached &&
            c.State != EntityState.Unchanged))
        {
            //the `entry` is of type IAuditableEntity, so you can access it's members
            if (entry.State == EntityState.Added)
            {
                entry.created_by = "your user";
                entry.created_time = DateTime.UtcNow;
            }
            else if (entry.State == EntityState.Modified)
            {
                //modified data here
            }
           
            else if (entry.State == EntityState.Deleted)
                //deleted logic here: you are not using this. You could use it to log a delete
        }
    }
