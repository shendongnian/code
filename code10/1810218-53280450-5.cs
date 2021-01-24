    public class Class1
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        [JsonExtensionData]
        public Dictionary<string, JToken> _JTokenProperty { get; set; }
        public Dictionary<string, PropertiesClass> Properties1 { get; set; } = new Dictionary<string, PropertiesClass>();
    }
