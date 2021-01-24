               //  using MongoDB.Driver;
               //  using MongoDB.Bson;
                 private static Object GetCollection()
                  {
                    IMongoClient  _client = new MongoClient();
                    IMongoDatabase _database = _client.GetDatabase("<urDBname>");
                    var _collection = _database.GetCollection<ToDo>("<urCOLLECTIONname>");
                    var documents = _collection.Find(new BsonDocument()).ToListAsync().Result;
                    return documents;
                  }
