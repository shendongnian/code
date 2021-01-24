    public static class MongoDataService
    {
        public static async Task<List<BsonDocument>> GetDocumentCollectionAsync(
            MongoClient client, FilterDefinition<BsonDocument> filter,
            string databaseName, string collectionName, CancellationToken token,
            int? limit = null)
        {
            return await Task.Run(async () =>
            {
                long i = 1;
                List<BsonDocument> items = new List<BsonDocument>();
                var collection = GetCollection<BsonDocument>(client, databaseName, collectionName);
                using (var cursor = await collection.FindAsync(filter))
                {
                    while (await cursor.MoveNextAsync())
                    {
                        var batch = cursor.Current;
                        foreach (var doc in batch)
                        {
                            items.Add(doc);
                            
                            if (token.IsCancellationRequested || i == limit)
                                return items;
                            i++;
                        }
                    }
                }
                return items;
            }, token);
        }
    }
    
