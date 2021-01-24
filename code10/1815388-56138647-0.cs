	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		// guid identities
		foreach (var entity in modelBuilder.Model.GetEntityTypes()
			.Where(t =>
				t.ClrType.GetProperties()
					.Any(p => p.CustomAttributes.Any(a => a.AttributeType == typeof(DatabaseGeneratedAttribute)))))
		{
			foreach (var property in entity.ClrType.GetProperties()
				.Where(p => p.PropertyType == typeof(Guid) && p.CustomAttributes.Any(a => a.AttributeType == typeof(DatabaseGeneratedAttribute))))
			{
				modelBuilder
					.Entity(entity.ClrType)
					.Property(property.Name)
					.HasDefaultValueSql("newsequentialid()");
			}
		}
	}  
