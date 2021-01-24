    public class Rootobject
    {
        public string action { get; set; }
        public string method { get; set; }
        public Datum[][] data { get; set; }
        public string type { get; set; }
        public int tid { get; set; }
    }
    public class Datum
    {
        public int AgreementTypeId { get; set; }
        public string Value { get; set; }
        public bool IsDeleted { get; set; }
    }
