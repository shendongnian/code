    public class RECORD
    {
        public string ENGINE { get; set; }
        public string CHASSIS { get; set; }
        public string PRODH { get; set; }
        public string LANDX { get; set; }
        public string AUART { get; set; }
        public object WADAT_IST { get; set; }
    }
    
    public class RootObject
    {
        public List<RECORD> RECORDS { get; set; }
    }
