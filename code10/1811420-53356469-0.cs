    public class Entity
    {
    	public ObjectId id { get; set; }
    	public string name { get; set; }
    }
    // Find the documents to delete
    var test = db.GetCollection<Entity>("test");
    var filter = new BsonDocument();
    var docs = test.Find(filter).ToList();
    // Get the _id values of the found documents
    var ids = docs.Select(d => d.id);
    // Create an $in filter for those ids
    var idsFilter = Builders<Entity>.Filter.In(d => d.id, ids);
    // Delete the documents using the $in filter
    var result = test.DeleteMany(idsFilter);
