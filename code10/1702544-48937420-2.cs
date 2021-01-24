    public class OutputItem
    {
        public Message Message { get; set; }
        public long Int64Value { get; set; }                     // 5
        public string StringThatLooksLikeCurrency { get; set; }  // "$0.64"
        public string StringThatLooksNumeric { get; set; }       // "1519294200"
    }
    public class Message
    {
        public string MessageId { get; set; }                    // "449940"
        public string MessageText { get; set; }                  // "! That Dude..."
    }
