    public class Warning
    {
        public string message { get; set; }
        public string numbers { get; set; }
    }
    
    public class Message
    {
        public int num_parts { get; set; }
        public string sender { get; set; }
        public string content { get; set; }
    }
    
    public class Message2
    {
        public string id { get; set; }
        public long recipient { get; set; }
    }
    
    public class RootObject
    {
        public List<Warning> warnings { get; set; }
        public int balance { get; set; }
        public int batch_id { get; set; }
        public int cost { get; set; }
        public int num_messages { get; set; }
        public Message message { get; set; }
        public string receipt_url { get; set; }
        public string custom { get; set; }
        public List<string> inDND { get; set; }
        public List<Message2> messages { get; set; }
        public string status { get; set; }
    }
