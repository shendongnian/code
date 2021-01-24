    public async Task<TenantDetails> ReadBrokerSettings(string tenantId)
    {
    	FeedOptions queryOptions = new FeedOptions { MaxItemCount = 1 };
    
    	var query = this._client.CreateDocumentQuery<TenantDTO>(
    		 UriFactory.CreateDocumentCollectionUri(_idDatabase, _idCollection), queryOptions)
    		 .Where(f => f.tenantId == tenantId).AsDocumentQuery();
    
    	while(query.HasMoreResults)
    	{
    		var results = await query.ExecuteNextAsync<TenantDTO>();
    		if(results.Any())
    		{
    			return _iTenantAssembler.DtoToEntity(results.Single());
    		}
    	}
    		 
    	return null;
    }
