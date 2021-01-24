    var redact = new BsonDocument()
            {
            {"$redact",
                    new BsonDocument
                    {
                        {
                            "$cond", new BsonDocument(){
                            {
                                "if", new BsonDocument()
                                {
                                    { "$gte", new BsonArray
                                        {
                                            new BsonDocument{
                                            {
                                                "$divide", new BsonArray{"$nA", "$wT"}
                                            },
                                        },
                                        sPacketMSItem.FromDPC.Value
                                        }
                                    }
                                }
                            },
                            {  "then", "$$KEEP"  },
                            {  "else", "$$PRUNE" }
                        }
                        }
                    }
            }
        };
    var result = Col.Aggregate()
                    .AppendStage<BsonDocument>(redact).ToList();
