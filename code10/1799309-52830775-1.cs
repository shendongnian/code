    public class AffectedSegment
    {
        public string Line { get; set; }
        public string Direction { get; set; }
        public string Stations { get; set; }
        public string MRTShuttleDirection { get; set; }
    }
    
    public class Message
    {
        public string Content { get; set; }
        public string CreatedDate { get; set; }
    }
    
    public class Value
    {
        public int Status { get; set; }
        public List<AffectedSegment> AffectedSegments { get; set; }
        public List<Message> Message { get; set; }
    }
    
    public class RootObject
    {
        public Value value { get; set; }
    }
