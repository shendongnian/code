    public class Notification
    {
        public string title { get; set; }
        public string text { get; set; }
        public string sound { get; set; }
    }
    
    public class RootObject
    {
        public string to { get; set; }
        public Notification notification { get; set; }
    }
