    class Rooot
    {
        public Dictionary<string, BankDetail> Result { get; set; }
    }
    
    public class BankDetail
    {
        public string BANK { get; set; }
        public string IFSC { get; set; }
        public string BRANCH { get; set; }
        public string ADDRESS { get; set; }
        public object CONTACT { get; set; }
        public string CITY { get; set; }
        public string DISTRICT { get; set; }
        public string STATE { get; set; }
    }
    
