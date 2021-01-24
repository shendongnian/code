    public override int SaveChanges()
    {
    	foreach (var ent in ChangeTracker.Entries<Client>())
    	{
    		if (ent.State == EntityState.Modified)
    		{
    			// Get the changed values
    			var modifiedProps = ObjectStateManager.GetObjectStateEntry(ent.EntityKey).GetModifiedProperties();
    			var currentValues = ObjectStateManager.GetObjectStateEntry(ent.EntityKey).CurrentValues;
    			foreach (var propName in modifiedProps)
    			{
    				var newValue = currentValues[propName];
    				//log your changes
    			}
    		}
    	}
    
    	return base.SaveChanges();
    }
