    var collectionUri = UriFactory.CreateDocumentCollectionUri(CDBdatabase, CDBcollection);
    
    var query = documentClient.CreateDocumentQuery<ConsumerDetails>(
    	collectionUri)
        .Where(f => f.Id == consumerId)
    	.AsDocumentQuery();
    
    List<ConsumerDetails> results = new List<ConsumerDetails>();
    while (query.HasMoreResults)
    {
    	results.AddRange(await query.ExecuteNextAsync<ConsumerDetails>());
    }
    
    return results.FirstOrDefault();
