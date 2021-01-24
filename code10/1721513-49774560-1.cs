    public class NewField
    {
        [JsonProperty("op")]
        public string op = "add";
        [JsonProperty("path")]
        public string path;
        [JsonProperty("value")]
        public object value;
    }
