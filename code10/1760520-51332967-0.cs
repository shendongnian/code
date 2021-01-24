    public partial class Root
    {
        [JsonProperty("result")]
        public List<Result> Result { get; set; }
        [JsonProperty("first")]
        public DateTimeOffset First { get; set; }
        [JsonProperty("last")]
        public DateTimeOffset Last { get; set; }
    }
    public partial class Result
    {
        [JsonProperty("tags")]
        public List<Tag> Tags { get; set; }
        [JsonProperty("custom_tags")]
        public List<string> CustomTags { get; set; }
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("blurb")]
        public string Blurb { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("published_at")]
        public DateTimeOffset PublishedAt { get; set; }
        [JsonProperty("thumbnail")]
        public Banner Thumbnail { get; set; }
        [JsonProperty("banner")]
        public Banner Banner { get; set; }
    }
    public partial class Banner
    {
        [JsonProperty("small")]
        public string Small { get; set; }
        [JsonProperty("medium")]
        public string Medium { get; set; }
        [JsonProperty("large")]
        public string Large { get; set; }
        [JsonProperty("original")]
        public string Original { get; set; }
    }
    public partial class Tag
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("subscribed")]
        public bool Subscribed { get; set; }
    }
