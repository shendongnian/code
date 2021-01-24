    void ConfigureTenant<TEntity>(ModelBuilder modelBuilder) where TEntity : class
    {
    	modelBuilder.Entity<TEntity>(builder =>
    	{
    		builder.Property<int>("TenantId")
    			.HasValueGenerator<TenantIdValueGenerator>();
    
    		builder.HasQueryFilter(e => EF.Property<int>(e, "TenantId") == _tenantProvider.GetTenantId());
    	});
    }
