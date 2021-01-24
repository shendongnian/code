    [HttpGet]
    public ActionResult<Tuple<string, string>> Get()
    {
        var client = new MongoClient(CLIENT);
        var database = client.GetDatabase(DATABASE);
        var collection = database.GetCollection<BsonDocument>(COLLECTION);
        var document = collection.AsQueryable().Sample(1).First();
        var city = document.GetValue("name").ToString();
        var country = document.GetValue("country").ToString();
        Tuple<string, string> result = new Tuple<string, string>(city, country);
        Response.ContentType = "application/json";
        return result;
    }
