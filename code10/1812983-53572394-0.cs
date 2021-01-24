    var client = new MongoClient(new MongoClientSettings()
    {
        ApplicationName = "Sackoverflow-Question-53393041"
    });
    var database = client.GetDatabase("test");
    var collection = database.GetCollection<BsonDocument>("test");
    
    collection.InsertOne(new BsonDocument()
    {
        {"_id", 1 }
    });
	
