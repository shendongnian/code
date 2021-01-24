    public static IMongoCollection<T> GetCollectionIfExists<T>(this IMongoDatabase database, string collectionName)
    {
        var command = $"{{ collStats: \"{collectionName}\", scale: 1 }}";
        try
        {
            database.RunCommand<BsonDocument>(command);
            return database.GetCollection<T>(collectionName);
        }
        catch(MongoCommandException e) when (e.ErrorMessage.EndsWith("not found."))
        {
            return null;
        }
    }
