    internal void Upsert(object entity)
    {
        ChangeTracker.TrackGraph(entity, e =>
        {
            if (e.Entry.IsKeySet)
            {
                e.Entry.State = EntityState.Modified;
            }
            else
            {
                e.Entry.State = EntityState.Added;
            }
        });
        #if DEBUG
        foreach (var entry in ChangeTracker.Entries())
        {
            Debug.WriteLine($"Entity: {entry.Entity.GetType().Name} State: {entry.State.ToString()}");
        }
        #endif
    }
