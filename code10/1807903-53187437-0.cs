    public override int SaveChanges()
    {
        var changedEntriesCopy = ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added ||
                    e.State == EntityState.Modified ||
                    e.State == EntityState.Deleted)
                    .ToList();
        var saveTime = DateTime.Now;
            foreach (var entityEntry in changedEntriesCopy)
            {
                if (entityEntry.Metadata.FindProperty("Created") != null && entityEntry.Property("Created").CurrentValue == null)
                {
                    entityEntry.Property("Created").CurrentValue = saveTime;
                }
                if (entityEntry.Metadata.FindProperty("Updated") != null)
                {
                    entityEntry.Property("Updated").CurrentValue = saveTime;
                }
            }
        return base.SaveChanges();
    }
