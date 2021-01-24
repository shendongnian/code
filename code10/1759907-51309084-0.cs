	//define the collection and a sample BsonDocument:
	var collectionName = "bsonDocs";
	var bsonDoc = BsonDocument.Parse("{ \"_id\" : ObjectId(\"5b476c4b7d1c1647b06f8e75\"), \"Detail\" : \"testString1\", }");
	//Establish connection to database
	var clientInstance = new MongoClient();
	var db = clientInstance.GetDatabase("TEST");
	//Get the collection as BsonDocuments
	var collection = db.GetCollection<BsonDocument>(collectionName);
	//Insert a BsonDocument
	collection.InsertOne(bsonDoc);
	//Get the same collection, this time as your data model type
	var modelCollection = db.GetCollection<TestDataModel>(collectionName);
	//Query that collection for your data models
	var models = modelCollection.AsQueryable().FirstOrDefault();
	//Write data models to that same collection
	modelCollection.InsertOne(new TestDataModel{Detail = "new Item"});
