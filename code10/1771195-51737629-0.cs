    public override int SaveChanges()
    {
        var entries = ChangeTracker.Entries().Where(x => x.Entity is EntityBase && (x.State == EntityState.Added || x.State == EntityState.Modified));
        foreach (var entry in entries)
        {
            var entity = (EntityBase)entry.Entity;
            //do something
        }
        return base.SaveChanges();
    }
