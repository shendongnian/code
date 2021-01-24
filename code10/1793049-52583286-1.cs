    public partial class Job {
        [JsonProperty("object")]
        public string Object { get; set; }
        [JsonProperty("entry")]
        public Entry[] Entry { get; set; }
        [JsonProperty("resource_url")]
        public Uri ResourceUrl { get; set; }
    }
    public partial class Entry {
        [JsonProperty("uuid")]
        public string Uuid { get; set; }
        [JsonProperty("changed_fields")]
        public string[] ChangedFields { get; set; }
        [JsonProperty("time")]
        public DateTimeOffset Time { get; set; }
    }
