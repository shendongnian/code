    public static IMongoCollection<BsonDocument> ConnectDB(string _collection)
        {
            MongoClient _client = new MongoClient("mongodb://localhost:27017");
            switch (_collection) 
            {
            case 'Car':
                 var _db = _client.GetDatabase("cars_db");
                 return _db.GetCollection<Car>(_collection);
               break;
            
            case 'Season':
               var _db = _client.GetDatabase("season_db");
               return _db.GetCollection<Season>(_collection);
               break;
            case 'client':
               var _db = _client.GetDatabase("client_db");
               return _db.GetCollection<Client>(_collection);
              break;
            }
         }  
