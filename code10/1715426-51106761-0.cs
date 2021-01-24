    public class Sequence
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; }
        public string SequenceName { get; set; }
        public int SequenceValue { get; set; }
    }
