    static internal async Task<DocumentCollection> CreatePartitionedCollectionAsync(DocumentClient client, string databaseName,
                string collectionName, int collectionThroughput)
            {
                PartitionKeyDefinition partitionKey = new PartitionKeyDefinition
                {
                    Paths = new Collection<string> { ConfigurationManager.AppSettings["CollectionPartitionKey"] }
                };
                DocumentCollection collection = new DocumentCollection { Id = collectionName, PartitionKey = partitionKey };
    
                try
                {
                    collection = await client.CreateDocumentCollectionAsync(
                        UriFactory.CreateDatabaseUri(databaseName),
                        collection,
                        new RequestOptions { OfferThroughput = collectionThroughput });
                }
                catch (Exception e)
                {
                    throw e;
                }
    
                return collection;
            }
