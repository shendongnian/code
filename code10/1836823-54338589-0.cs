    BsonArray subpipeline = new BsonArray();
    subpipeline.Add(
        new BsonDocument("$match",new BsonDocument(
            "$expr", new BsonDocument(
            "$and", new BsonArray { 
                 new BsonDocument("$eq", new BsonArray{"$stock_item", "$$order_item"} ), 
                 new BsonDocument("$gte", new BsonArray{"$instock", "$$order_qty"} )
                 }  
            )
        ))
    );
    var lookup = new BsonDocument("$lookup", 
                     new BsonDocument("from", "warehouses")
                                 .Add("let", 
                                     new BsonDocument("order_item", "$item")
                                                 .Add("order_qty", "$ordered"))
                                 .Add("pipeline", subpipeline)
                                 .Add("as", "stockdata")
    );
    
    var results = collection.Aggregate()
                            .Match(new BsonDocument("_id", 1))
                            .AppendStage<BsonDocument>(lookup).ToEnumerable();
    foreach (var x in results)
    {
        Console.WriteLine(x.ToJson());
    } 
