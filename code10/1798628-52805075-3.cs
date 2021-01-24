    var entityTypes = modelBuilder.Model.GetEntityTypes()
    	.Where(t => typeof(Common).IsAssignableFrom(t.ClrType));
    foreach (var entityType in entityTypes)
    {
    	var configurationType = typeof(CommonEntityTypeConfiguration<>)
    		.MakeGenericType(entityType.ClrType);
    	modelBuilder.ApplyConfiguration(
    		(dynamic)Activator.CreateInstance(configurationType));
    }
