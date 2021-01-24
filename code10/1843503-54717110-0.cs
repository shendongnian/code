public override int SaveChanges(bool acceptAllChangesOnSuccess)
{
    // Note that this is internal code to force cascade deletes to happen.
    // It may stop working in any future release.
    ChangeTracker.DetectChanges();
    this.GetService<IStateManager>().GetEntriesToSave();
    try
    {
        ChangeTracker.AutoDetectChangesEnabled = false;
        foreach (var entry in ChangeTracker
            .Entries<CritiqueText>()
            .Where(e => Entry(e.Entity.Review).State == EntityState.Deleted))
        {
            entry.State = EntityState.Deleted;
        }
    }
    finally
    {
        ChangeTracker.AutoDetectChangesEnabled = true;
    }
    return base.SaveChanges(acceptAllChangesOnSuccess);
}
I took this and build an attribute based solution from this that you can find in the [test project repo](https://github.com/bert2/ef-vs-garbage-db/blob/master/GarbageDb/BloggingContext.cs).
