    public class Value
    {
        public object Reference { get; set; }
        public string Key { get; set; }
        public int IssueNumber { get; set; }
    }
    public class Message
    {
        public List<Value> value { get; set; }
    }
    public class ReciveModel
    {
        public Message message { get; set; }
    }
