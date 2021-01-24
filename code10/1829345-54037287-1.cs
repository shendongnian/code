    public async Task<TenantDetails> ReadBrokerSettings(string tenantId)
    {
    	var tenant = await tenantStore.Query().SingleOrDefaultAsync(f => f.tenantId == tenantId);
    	return _iTenantAssembler.DtoToEntity(tenant);
    }
