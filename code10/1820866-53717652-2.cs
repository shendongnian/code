    public class Series
    {
        public string name { get; set; }
        [JsonExtensionData]
        public IDictionary<string,JToken> tags { get; set; }
        public List<string> columns { get; set; }
        public List<List<object>> values { get; set; }
    }
