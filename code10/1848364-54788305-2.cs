    public class PayloadData
    {
        public List<string> CustomFields { get; set; }
        public string SampleNumber { get; set; }
    }
    
    public class RootObject
    {
        public PayloadData PayloadData { get; set; }
    }
