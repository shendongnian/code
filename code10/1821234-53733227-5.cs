        public class Skin : ServiceMongoIdentity
    {
       
         //removed some properties for brevity.
        [BsonIgnoreIfDefault]
        [BsonDefaultValue(SkinType.StringValue)]
        [BsonSerializer(typeof(StringTypeSerializer<SkinType>))]
        public SkinType Type { get; set; } = SkinType.StringValue;
    }
