        public override int SaveChanges()
        {
		
            var changes = from e in this.ChangeTracker.Entries()
                          where e.State != System.Data.EntityState.Unchanged
                          select e;
            foreach (var change in changes)
            {
                if (change.State == System.Data.EntityState.Added)
                {
                    // Log Added
                }
                else if (change.State == System.Data.EntityState.Modified)
                {
			        // Log Modified
			        var item = change.Cast<IEntity>().Entity;
			        var originalValues = this.Entry(item).OriginalValues;
			        var currentValues = this.Entry(item).CurrentValues;
			
			        foreach (string propertyName in originalValues.PropertyNames)
                    {
        				var original = originalValues[propertyName];
		        		var current = currentValues[propertyName];
				
				        if (!Equals(original, current))
        				{
		        		    // log propertyName: original --> current
				        }
                    }
			
        		}
        		else if (change.State ==  System.Data.EntityState.Deleted)
		        {
        			// log deleted
		        }
        }
