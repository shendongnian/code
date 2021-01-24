    var collectionUri = UriFactory.CreateDocumentCollectionUri(_configuration.DatabaseName, _configuration.CollectionName);
    
    _logger.Information("Perform index transformation");
    _logger.Information("Create a collection with indexing policy");
    
    var collection = new DocumentCollection { Id = _configuration.CollectionName };
    collection.IndexingPolicy.IncludedPaths.Add(new IncludedPath
    {
    	Path = "/*",
    	Indexes = new Collection<Index> {
    		new RangeIndex(DataType.String) { Precision = -1 },
    		new RangeIndex(DataType.Number) { Precision = -1 } }
    });
    
    var createdCollection = await _client.CreateDocumentCollectionIfNotExists(collection, _configuration.DatabaseName);
    _logger.Information("Collection {0} created with index policy \n{1}", collection.Id, collection.IndexingPolicy);
    
    _logger.Information("Change the collection's indexing policy, and then do a replace operation on the collection");
    createdCollection.IndexingPolicy.IndexingMode = IndexingMode.Consistent;
    await _client.ReplaceDocumentCollectionAsync(createdCollection);
    
    _logger.Information("Check progress and wait for completion - should be instantaneous since we have only a few documents, but larger collections will take time...");
    await WaitForIndexTransformation(createdCollection);
