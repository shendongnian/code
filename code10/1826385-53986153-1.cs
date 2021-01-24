    var client = new MongoClient(myConnectionString);
    var db = client.GetDatabase("myDb");
    var guid = Guid.NewGuid();
    
    // create a class
    var doc = new MyDoc { Id = guid };
    var coll = db.GetCollection<MyDoc>("myColl");
    coll.InsertOne(doc);
    // we use a type that correspond to our busines layer/logic
    // that's the easier way because you can use Linq syntax so we're far from JSON and document issues
    // plus it's super readable in C#
    var foundDoc = coll.Find(d => d.Id == guid).FirstOrDefault();
    Console.WriteLine(foundDoc.Id);
    ...
    // the typed-document (class)
    class MyDoc
    {
        [BsonId]
        public Guid Id { get; set; }
        ... other properties...
    }
