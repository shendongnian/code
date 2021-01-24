    public static IMongoDatabase GetDatabaseIfExists(this IMongoClient client, string databaseName)
    {
        var database = client.GetDatabase(databaseName);
        var command = "{ dbStats: 1, scale: 1 }";
        var dbStats = database.RunCommand<BsonDocument>(command);
        var databaseExists = dbStats["collections"].AsInt32 > 0 || dbStats["indexes"].AsInt32 > 0;
        return databaseExists ? database : null;
    }
