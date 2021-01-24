    public class Rootobject
    {
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public int testvalues_count { get; set; }
        public Testvalue[] testvalues { get; set; }
    }
    public class Testvalue
    {
        public int id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
    }
