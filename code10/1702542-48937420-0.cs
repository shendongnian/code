    public class OutputItem
    {
        public Message Message { get; set; }
        public long Int64Value { get; set; }
        public string StringThatLooksLikeCurrency { get; set; }
        public string StringThatLooksNumeric { get; set; }
    }
    public class Message
    {
        public string MessageId { get; set; }
        public string MessageText { get; set; }
    }
