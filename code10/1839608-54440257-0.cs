    private string GetName()
    {
        var client = new MongoClient();
        var database = client.GetDatabase("WorldCities");
        var collection = database.GetCollection<BsonDocument>("cities");
        return collection.AsQueryable().Sample(1).First().GetValue("name").ToString();
    }
