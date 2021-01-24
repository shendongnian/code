    BsonClassMap.RegisterClassMap<MyEntity>(cm =>
    {
        cm.AutoMap();
        cm.MapIdMember(c => c.Id)
            .SetIdGenerator(StringObjectIdGenerator.Instance)
            .SetSerializer(new StringSerializer(BsonType.ObjectId));
    });
