    public class DataItem {
        [JsonProperty("id")]
        string id;
    
        [JsonProperty("data")]
        public Dictionary<string, JToken> data;
    }
