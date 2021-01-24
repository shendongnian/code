    var client = new MongoClient();
    
      IMongoDatabase db = client.GetDatabase("school");
    
      var collection = db.GetCollection<BsonDocument>("students");
    
      using (IAsyncCursor<BsonDocument> cursor = await collection.FindAsync(new BsonDocument()))
      {
        while (await cursor.MoveNextAsync())
        {
          IEnumerable<BsonDocument> batch = cursor.Current;
          foreach (BsonDocument document in batch)
          {
            Console.WriteLine(document);
            Console.WriteLine();
          }
        }
      }
