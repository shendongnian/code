    public class Series
    {
        public string name { get; set; }
        public Dictionary<string, JToken> tags { get; set; }
        public List<string> columns { get; set; }
        public List<List<object>> values { get; set; }
    }
