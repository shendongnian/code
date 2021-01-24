	public async Task<bool> ArrayContainsAsync()
	{
		var documentClient = new DocumentClient(new Uri("https://localhost:8081"), "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==");
		var collectionUri = UriFactory.CreateDocumentCollectionUri("dbname", "collectionName");
		var query = documentClient
			.CreateDocumentQuery<Item>(collectionUri, new FeedOptions { EnableCrossPartitionQuery = true })
			.Where(x => x.States.Contains("California")).Select(x=> x.Id).AsDocumentQuery();
		while (query.HasMoreResults)
		{
			var results = await query.ExecuteNextAsync();
			if (results.Any())
				return true;
		}
		return false;
	}
