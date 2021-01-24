    "$or", new BsonArray
    {
        new BsonDocument
        {
            { "Schedule.End.ByDate", BsonNull.Value }
        },
        new BsonDocument
        {
            {
                "Schedule.End.ByDate", new BsonDocument
                {
                    { "$gte", DateTime.UtcNow }
                }
            }
        }
    }
