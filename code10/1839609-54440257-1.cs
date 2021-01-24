    private string GetName()
    {
        var client = new MongoClient();
        var database = client.GetDatabase("WorldCities");
        var collection = database.GetCollection<BsonDocument>("cities");
        var result = collection.Find(FilterDefinition<BsonDocument>.Empty)
            .Project(Builders<BsonDocument>.Projection.Include("name").Exclude("_id")).First().ToString();
        return result;
        // { "name" : "les Escaldes" }
    }
