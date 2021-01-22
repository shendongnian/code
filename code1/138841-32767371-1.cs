    var entries = ((DbContext)ef).ChangeTracker.Entries();
    foreach (var entry in entries)
    {
        entry.State = System.Data.EntityState.Detached;
    }
