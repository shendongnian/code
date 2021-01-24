    public async Task CreateIndexOnCollection(IMongoCollection<BsonDocument> collection, string field)
    {
        var keys = Builders<BsonDocument>.IndexKeys.Ascending(field);
        await collection.Indexes.CreateOneAsync(keys);
    }
