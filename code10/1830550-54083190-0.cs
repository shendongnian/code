    public class Row
    {
        public string id { get; set; }
        public List<string> cell { get; set; }
    }
    public class Voyage
    {
        public string page { get; set; }
        public int total { get; set; }
        public string records { get; set; }
        public List<Row> rows { get; set; }
    }
    
