    public bool IsSoftDelete { get; set; }
    
    public override int SaveChanges()
    {
       ...
    // Modified State
        			var modified = this.ChangeTracker.Entries()
        						.Where(t => t.State == EntityState.Modified)
        						.Select(t => t.Entity)
        						.ToArray();
        
        			foreach (var entity in modified)
        			{
        				if (entity is ITrack)
        				{
        					var track = entity as ITrack;
        					Entry(track).Property(x => x.CreatedDate).IsModified = false;
        					Entry(track).Property(x => x.CreatedBy).IsModified = false;
        					track.ModifiedDate = DateTime.UtcNow;
        					track.ModifiedBy = UserId;
        
        					if (IsSoftDelete)
        					{
        						track.IsDeleted = true;
        						track.DeletedDate = DateTime.UtcNow;
        						track.DeletedBy = UserId;
        					}
        				}
        			}
