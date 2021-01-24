    public async Task SaveAsync(IEnumerable<JObject> models)
    {
        foreach (var document in models)
        {
            var collectionLink = UriFactory.CreateDocumentCollectionUri(_databaseName, _collectionName);
            await _client.CreateDocumentAsync(collectionLink, document);
        }
    }
