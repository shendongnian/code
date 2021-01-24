    public class SyncDocument 
    {
        // ...
        [BsonElement("locked"), BsonDefaultValue(false)]
        public bool Locked { get; set; }
    }
