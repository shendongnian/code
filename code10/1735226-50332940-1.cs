    var configureTenantMethod = GetType().GetTypeInfo().DeclaredMethods.Single(m => m.Name == nameof(ConfigureTenantFilter));
    var args = new object[] { modelBuilder };
    var tenantEntityTypes = modelBuilder.Model.GetEntityTypes()
    	.Where(t => typeof(ITenantEntity).IsAssignableFrom(t.ClrType));
    foreach (var entityType in tenantEntityTypes)
    	configureTenantMethod.MakeGenericMethod(entityType.ClrType).Invoke(this, args);
