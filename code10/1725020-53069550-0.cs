    using(var db = new LiteDatabase(@"C:\Temp\MyData.db"))
    {
        var col = db.GetCollection<Customer>("customers");
    
        // Index document using document Name property
        col.EnsureIndex(x => x.Name);
    	
        // Use LINQ to query documents
        var results = col.Find(x => x.Name.StartsWith("Jo"));
    
        // Let's create an index in phone numbers (using expression). It's a multikey index
        col.EnsureIndex(x => x.Phones, "$.Phones[*]"); 
    
        // and now we can query phones
        var r = col.FindOne(x => x.Phones.Contains("8888-5555"));
    }
