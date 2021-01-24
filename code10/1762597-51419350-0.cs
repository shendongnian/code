    public static class Extensions
    {
    	public static bool IsModified(this EntityEntry entry) =>
    		entry.State == EntityState.Modified ||
    		entry.References.Any(r => r.TargetEntry.Metadata.IsOwned() && IsModified(r.TargetEntry));
    }
