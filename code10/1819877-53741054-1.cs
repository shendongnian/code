    foreach (var entry in ChangeTracker.Entries()
                                        .Where(e => e.State == EntityState.Deleted &&
                                        e.Metadata.GetProperties().Any(x => x.Name == "IsDeleted")))
    {
    	SoftDelete(entry);
    }
