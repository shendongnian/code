     public partial class Users
    {
        [JsonProperty("count")]
        public long Count { get; set; }
        [JsonProperty("start_index")]
        public long StartIndex { get; set; }
        [JsonProperty("end_index")]
        public long EndIndex { get; set; }
        [JsonProperty("is_more")]
        public bool IsMore { get; set; }
        [JsonProperty("data")]
        public List<Datum> Data { get; set; }
    }
