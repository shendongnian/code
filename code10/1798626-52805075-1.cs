    foreach (var entityType in modelBuilder.Model.GetEntityTypes())
    {
    	if (typeof(Common).IsAssignableFrom(entityType.ClrType))
    		Configure((dynamic)modelBuilder.Entity(entityType.ClrType));
    }
