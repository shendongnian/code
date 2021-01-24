    static void Main(string[] args)
    {
        MongoClient client = new MongoClient();
        var db = client.GetDatabase("test");
        var collection = db.GetCollection<BsonDocument>("Collection");
    
        var document = new BsonDocument
        {
            { "date", 10/04/2018 },
            { "data", new BsonDocument{ getDocuments() } }
        };
        collection.InsertOneAsync(document);
        Console.Read();
    }
    static BsonDocument getDocuments()
    {
        var documents = new BsonDocument();
        for (int i = 1; i <= 5; i++)
        {
            var document = new BsonDocument
                   {
                       { "magnitude" + i, new BsonDocument { { "value", 5 } } }
                   };
             documents.AddRange(document);
         }
         return documents;
    }
