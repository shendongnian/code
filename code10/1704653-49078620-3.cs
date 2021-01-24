    public class JsonAppID
    {
        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }
        [JsonProperty(PropertyName = "term")]
        public string Term { get; set; }
    }
    public class RootObject
    {
        [JsonProperty("total_events")]
        public int TotalEvents { get; set; }
        [JsonProperty("json.appID")]
        [JsonConverter(typeof(TolerantObjectCollectionConverter<JsonAppID>))]
        public List<JsonAppID> AppIds { get; set; }
        [JsonProperty("unique_field_count")]
        public int UniqueFieldCount { get; set; }
    }
