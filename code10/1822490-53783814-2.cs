	class Parent
	{
	    public ObjectId Id;
	    //Remove the attribute. This field needs to be initialized
	    public IDictionary<string, List<Child>> Children = new Dictionary<string, List<Child>>();
	}
    class Child 
    { 
    	public string ChildName;  // This isn't needed
    }
	
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new MongoClient("mongodb://localhost:27017")
                .GetDatabase("Test").GetCollection<Parent>("Parents");
            
            var parent = new Parent();
            
            collection.InsertOne(parent);
            collection.UpdateOne(p => p.Id == parent.Id, 
                Builders<Parent>.Update
                    .Push(p => p.Children["string1"], new Child {ChildName = "I am the new guy!"}));
        }
    }
