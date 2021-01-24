    public class Model
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string ParentId { get; set; }
        // some other properties
    }
