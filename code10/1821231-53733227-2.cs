    public class Skin : ServiceMongoIdentity
    {
        public string Name { get; set; }
        /// <summary>
        /// Features that use this skin.  Leave blank if all features use it
        /// </summary>
        [BsonIgnoreIfDefault]
        public List<string> Features { get; set; }
        public string Value { get; set; }
        
        [BsonIgnoreIfDefault]
        [BsonDefaultValue(SkinTypes.StringValue)]
        [BsonSerializer(typeof(SkinTypeSerializer))]
        public SkinTypes Type { get; set; } = SkinTypes.StringValue;
 
    }
