    MongoClient client = new MongoClient("mongodb://localhost:27017");
    List<string> dbs = new List<string>();
    using (IAsyncCursor<BsonDocument> cursor = client.ListDatabases())
    {
        while (cursor.MoveNext())
        {
            foreach (var doc in cursor.Current)
                dbs.Add((string)doc["name"]); // database name
        }
    }
