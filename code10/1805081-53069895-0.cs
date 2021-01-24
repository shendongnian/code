    public override int SaveChanges()
    {
        var modifiedEntities = ChangeTracker.Entries()
            .Where(p => p.State == EntityState.Modified).ToList();
        var now = DateTime.UtcNow;
    
        foreach (var change in modifiedEntities)
        {
            var entityName = change.Entity.GetType().Name;
            var primaryKey = GetPrimaryKeyValue(change);
    
            foreach(var prop in change.OriginalValues.PropertyNames)
            {
                var originalValue = change.OriginalValues[prop].ToString();
                var currentValue = change.CurrentValues[prop].ToString();
                if (originalValue != currentValue) //Only create a log if the value changes
                {
                    //Create the Change Log
                }
            }
        }
        return base.SaveChanges();
    }
