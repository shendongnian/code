    var propertyNames = typeof(INotPersistingProperties).GetProperties()
    	.Select(p => p.Name)
    	.ToList();
    var entityTypes = modelBuilder.Model.GetEntityTypes()
    	.Where(t => typeof(INotPersistingProperties).IsAssignableFrom(t.ClrType));
    foreach (var entityType in entityTypes)
    {
    	var entityTypeBuilder = modelBuilder.Entity(entityType.ClrType);
    	foreach (var propertyName in propertyNames)
    		entityTypeBuilder.Ignore(propertyName);
    }
 
