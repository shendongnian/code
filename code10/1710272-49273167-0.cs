    public class Role
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ApplicationName { get; set; }
        [BsonElement("Role")]
        public string Name { get; set; }
    }
