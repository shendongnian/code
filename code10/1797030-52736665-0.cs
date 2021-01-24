    public class MongoContext
        {
            IMongoClient _client;
            public readonly IMongoDatabase _database;
            public MongoContext()
            {
                //Reading credentials from Web.config file
                _client = new MongoClient("mongodb://" + ConfigurationManager.AppSettings["MongoHost"] + ":" + ConfigurationManager.AppSettings["MongoPort"]);
                _database = _client.GetDatabase(ConfigurationManager.AppSettings["MongoDatabaseName"]);
            }
        }
