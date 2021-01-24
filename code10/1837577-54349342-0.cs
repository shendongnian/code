    RetrieveAllEntitiesRequest request = new RetrieveAllEntitiesRequest()
    {
    	EntityFilters = EntityFilters.Entity,
    	RetrieveAsIfPublished = true
    };
    
    RetrieveAllEntitiesResponse response = (RetrieveAllEntitiesResponse)_serviceProxy.Execute(request);
    
    foreach (EntityMetadata currentEntity in response.EntityMetadata)
    {
    	currentEntity.PrimaryIdAttribute
    }
