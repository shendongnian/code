    public class MainClass
    {
        public string MyStringValue { get; set; }
        [JsonConverter(typeof(SecondClassConverter))]
        public SecondClass MyClassValue { get; set; }
    }
    public class SecondClass
    {
        public string Value { get; set; }
    }
