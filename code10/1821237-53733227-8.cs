        public class Skin : ServiceMongoIdentity
    {
       
         //removed some properties for brevity.
        [BsonIgnoreIfDefault]
        [BsonDefaultValue(SkinType.StringValue)]
        public SkinType Type { get; set; } = SkinType.StringValue;
    }
