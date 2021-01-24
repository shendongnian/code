	internal class MyDocument
	{
		public ObjectId Id { get; set; }
		public string Name { get; set; }
		public Dictionary<string, string> AdditionalData { get; set; }
	}
	
	var collection = new MongoClient().GetDatabase("test").GetCollection<MyDocument>("docs");
	var myDocument = new MyDocument
	{
	    Name = "test",
	    AdditionalData = new Dictionary<string, string>
	    {
	        ["boardId"] = "149018"
	    }
	};
	collection.InsertOne(myDocument);
	
	// { "_id" : ObjectId("5b74093fbbbca64ba8ce9d0e"), "name" : "test", "additional_data" : { "board_id" : "149018" } }
	
