    public class Document
    {
        [BsonId]       
        [BsonIgnoreIfDefault]
        public ObjectId InternalId { get; set; }
        // rest of document
    }
