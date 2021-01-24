    public class EntityMap
    {
        public static void Register()
        {
            BsonClassMap.RegisterClassMap<Entity<int>>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(c => c.Id)
                    .SetIdGenerator(SeqIntIdGenerator<Entity<int>, Child>.Instance)
                    .SetSerializer(new Int32Serializer(BsonType.Int32));
            });
        }
    }
