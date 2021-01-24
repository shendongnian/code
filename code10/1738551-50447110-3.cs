    public class abc
    {
        public string field1 { get; set; }
    
        [JsonConverter(typeof(ObjectDictionaryConverter))]
        public Dictionary<string, char> field2 { get; set; }
    }
