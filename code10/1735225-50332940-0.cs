    void ConfigureTenantFilter<TEntity>(ModelBuilder modelBuilder)
    	where TEntity : class, ITenantEntity
    {
    	modelBuilder.Entity<TEntity>()
    		.HasQueryFilter(e => e.TenantId == this._appUserProvider.CurrentTenantId);
    }
