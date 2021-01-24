    BsonArray subpipeline = new BsonArray();
    
    subpipeline.Add(
      new BsonDocument("$match",new BsonDocument(
        "$expr", new BsonDocument(
          "$eq", new BsonArray { "$$entity", "$entity" }  
        )
      ))
    );
    
    var lookup = new BsonDocument("$lookup",
      new BsonDocument("from", "others")
        .Add("let", new BsonDocument("entity", "$_id"))
        .Add("pipeline", subpipeline)
        .Add("as","others")
    );
    
    var query = entities.Aggregate()
      .Match(p => listNames.Contains(p.name))
      .AppendStage<EntityWithOthers>(lookup)
      .Unwind<EntityWithOthers, EntityWithOther>(p => p.others)
      .SortByDescending(p => p.others.name)
      .ToList();
