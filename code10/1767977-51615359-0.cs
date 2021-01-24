    var addedEntities = ChangeTracker.Entries()
        .Where(e => e.State == EntityState.Added)
        .Select(e => e.Entity)
        .OfType<ModelBase>();
    
    foreach (var e in addedEntities)
    {
        // Here you modify the actual entity instance, so the values
        // you set will be considered by the base.SaveChanges() call
        e.CreatedOn = DateTime.Now;
        e.CreatedBy = userId;
    }
