    public class MongoContext
        {
            IMongoClient _client;
            public readonly IMongoDatabase _database;
            public MongoContext()
            {
                MongoCredential credential = MongoCredential.CreateCredential(ConfigurationManager.AppSettings["MongoMasterDatabaseName"], ConfigurationManager.AppSettings["MongoUsername"], ConfigurationManager.AppSettings["MongoPassword"]);
                var settings = new MongoClientSettings
                {
                    Credential = credential,
                    Server = new MongoServerAddress(, Convert.ToInt32(ConfigurationManager.AppSettings["MongoPort"]))
                };
                _client = new MongoClient(settings);
                _database = _client.GetDatabase(ConfigurationManager.AppSettings["MongoClientDatabaseName"]);
            }
        }
