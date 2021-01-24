    var filter1 = new BsonDocument()
                { 
                    {"$expr",
                            new BsonDocument(){
                            {
                                "$gte", new BsonArray{
                                    new BsonDocument{
                                    {
                                        "$divide", new BsonArray{"$nA", "$wT"}
                                    },
                                },
                                sPacketMSItem.FromDPC.Value
                            }
                        }
                        }
                    }
                };
