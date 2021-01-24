    public class Rootobject
    {
        public string TransferResult { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Application[] Applications { get; set; }
    }
    
    public class Application
    {
        public string AppSerial { get; set; }
        public string OfficialResult { get; set; }
    }
