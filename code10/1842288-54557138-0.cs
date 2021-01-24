    var mongo = new MongoClient();
	var db = mongo.GetDatabase("test");
	var col = db.GetCollection<BsonDocument>("col");
	await col.UpdateManyAsync(new BsonDocument(),
	Builders<BsonDocument>.Update.Unset("someArray.$[].IsReadOnly"));
