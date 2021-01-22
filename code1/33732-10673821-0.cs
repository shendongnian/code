    private IEnumerable<ObjectStateEntry> GetModifiedRelationshipEntries()
    {
        return ObjectStateManager.GetObjectStateEntries(
                EntityState.Added | EntityState.Deleted)
                .Where(e => e.IsRelationship);
    }
