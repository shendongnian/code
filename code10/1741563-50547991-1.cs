    public class RootObject
    {
        public DateTime clientTimestamp { get; set; }
        public string modifiedType { get; set; }
        public string type { get; set; }
        public long messageSize { get; set; }
        public Guid roomId { get; set; }
        public string messageContent { get; set; }
    }
