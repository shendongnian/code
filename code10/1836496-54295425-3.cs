    MongoCollection collection = db.GetCollection("matches");
    var query = new QueryDocument("recordId", recordId); //this is the filter
    
    var update = Update.Set("FirstName", "John").Set("LastName","Doe"); //these are the keys to be updated
    matchCollection.Update(query, update, UpdateFlags.Upsert, SafeMode.False);
