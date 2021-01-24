    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
    {
        foreach (var entry in ChangeTracker.Entries())
        {
           bool shouldUpdateReference = false;
           foreach (var reference in entry.References)
           {
               if (reference.TargetEntry != null && reference.TargetEntry.State == EntryState.Modified)
               {
                   shouldUpdateReference = true;
               }
           }
            // I imagine this has to be done outside the foreach 
            // since you are modifying a reference and that should 
            // update the References collection
            if (shouldUpdateReference)
            {
                entity.Reference("Owner").CurrentValue = newOwner; 
            }
        }
        return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
