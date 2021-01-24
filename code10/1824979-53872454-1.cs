    public class Rootobject
    {
        public string accountreference { get; set; }
        public Message[] messages { get; set; }
    }
    public class Message
    {
        public string to { get; set; }
        public string body { get; set; }
    }
