    foreach (var entityType in modelBuilder.Model.GetEntityTypes())
    {
    	if (typeof(IDeleted).IsAssignableFrom(entityType.ClrType))
    		entityType.AddQueryFilter<IDeleted>(e => e.DateTimeDeleted == null);
    }
