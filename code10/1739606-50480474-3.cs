    public class Lab
    {
        public string name { get; set; }
        public string branch { get; set; }
        public string buildno { get; set; }
    }
    
    public class RootObject
    {
        public List<Lab> lab { get; set; }
    }
