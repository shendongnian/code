    class TenantIdValueGenerator : ValueGenerator<int>
    {
    	public override bool GeneratesTemporaryValues => false;
    	public override int Next(EntityEntry entry) => GetTenantId(entry.Context);
    	int GetTenantId(DbContext context) => ((YourDbContext)context)._tenantProvider.GetTenantId();
    }
