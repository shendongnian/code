    [HttpGet]
    public async Task<IEnumerable<Person>> Get()
    {
    	this.client = new DocumentClient(new Uri(EndpointUri), PrimaryKey);
    	FeedOptions queryOptions = new FeedOptions { EnableCrossPartitionQuery = true };
    	
    	var personQuery = this.client.CreateDocumentQuery<Person>(
    		UriFactory.CreateDocumentCollectionUri(DbId, CollectionId), queryOptions)
    		.Where(f => f.NameFirst != "Andersen").Take(25).AsDocumentQuery();
    
    	List<Person> retVal = new List<Person>();
    	
    	while(personQuery.HasMoreResults)
    	{
    		var results = await personQuery.ExecuteNextAsync();
    		retVal.AddRange(results);
    	}
    	
    	return retVal;
    }
