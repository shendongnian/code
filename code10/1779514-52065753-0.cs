    IMongoCollection<Entity> collection = GetMyCollection();
    DateTime minDate = default(DateTime); // define this yourself
    DateTime maxDate = default(DateTime); // define this yourself
    var match = new BsonDocument
    { {
        "$match", new BsonDocument
        { {
            "TimeStamp", new BsonDocument
            { {
                "$and", new BsonDocument
                {
                    { "$gt", minDate },
                    { "$lt", maxDate }
                }
            } }
        } }
    } };
    var group = new BsonDocument
    { {
        "$group", new BsonDocument
        {
            { "_id", BsonNull.Value },
            { "min", new BsonDocument { { "$min", "Value" } } },
            { "max", new BsonDocument { { "$max", "Value" } } },
            { "avg", new BsonDocument { { "$avg", "Value" } } },
        }
    } };
    var result = collection.Aggregate(PipelineDefinition<Entity, BsonDocument>.Create(match, group)).Single();
    double min = result["min"].AsDouble;
    double max = result["max"].AsDouble;
    double avg = result["avg"].AsDouble;
