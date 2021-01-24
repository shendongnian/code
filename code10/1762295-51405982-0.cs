    var auditableEntityTypes = modelBuilder.Model.GetEntityTypes().Where(t => t.ClrType.IsSubclassOf(typeof(AuditableEntity)));
    var webUserNavigations = new[] { nameof(AuditableEntity.CreatedBy), nameof(AuditableEntity.DeletedBy), nameof(AuditableEntity.UpdatedBy) };
    foreach (var entityType in auditableEntityTypes)
    {
    	modelBuilder.Entity(entityType.ClrType, builder =>
    	{
    		foreach (var webUserNavigation in webUserNavigations)
    			builder.HasOne(typeof(WebUser), webUserNavigation).WithMany();
    	});
    }
