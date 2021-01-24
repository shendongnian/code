    foreach (var entry in ChangeTracker.Entries()
                                        .Where(e => e.State == EntityState.Deleted &&
                                        e.Metadata.GetProperties().Any(x => x.Name == "IsDeleted")))
    {
    	switch (entry.State)
    	{
    		case EntityState.Added:
    			entry.CurrentValues["IsDeleted"] = false;
    			break;
    
    		case EntityState.Deleted:
    			entry.State = EntityState.Modified;
    			entry.CurrentValues["IsDeleted"] = true;
    			break;
    	}
    }
