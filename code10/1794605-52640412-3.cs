     public class Input
    {
        public string Region { get; set; }
        public string NamespaceName { get; set; }
        [Description("A set of key value pairs that define custom tags.")]
        [YourAttribute]
        public Dictionary<string, string> Tags { get; set; }
    }
