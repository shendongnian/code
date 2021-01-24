    public class Month
    {
        public string title { get; set; }
        public string titlePopup { get; set; }
        public string color { get; set; }
        public int msgId { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public int allDay { get; set; }
        public string attachment { get; set; }
        public string genFile { get; set; }
        public int is_Holiday { get; set; }
    }
    
    public class Data
    {
        public List<Month> Jan { get; set; }
        public List<Month> Feb { get; set; }
    }
    
    public class RootObject
    {
        public string ResponseStatus { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public Data data { get; set; }
    }
