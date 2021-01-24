         private string userName = "FILLME";
                private string host = "FILLME";            
                private string dbName = "Tasks";
                private string collectionName = "TasksList";
              private IMongoCollection<MyTask> GetTasksCollection()
              {
                MongoClientSettings settings = new MongoClientSettings();
                settings.Server = new MongoServerAddress(host, 10255);
                settings.UseSsl = true;
                settings.SslSettings = new SslSettings();
                settings.SslSettings.EnabledSslProtocols = SslProtocols.Tls12;
    
                MongoIdentity identity = new MongoInternalIdentity(dbName, userName);
                PasswordEvidence evidence = new PasswordEvidence(password);
                settings.Credential = new MongoCredential("SCRAM-SHA-1", identity, evidence);
                MongoClient client = new MongoClient(settings);
                var database = client.GetDatabase(dbName);
                var todoTaskCollection = database.GetCollection<MyTask>(collectionName);
                return todoTaskCollection;
            }
             public List<MyTask> GetAllTasks()
             {
               try
               {
                var collection = GetTasksCollection();
                return collection.Find(new BsonDocument()).ToList();
                }
                catch (MongoConnectionException ex)
                {
                  return new List<MyTask>();
                }
              }
