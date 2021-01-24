    public class ProjectCollection
    {
        [JsonProperty("projects")]
        public Dictionary<string, Project> Projects { get; set; }
    }
    public class Project
    {
        [JsonProperty("projectId")]
        public string Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("date")]
        public string Excerpt { get; set; }
        [JsonProperty("date")]
        public DateTime PublishedDate { get; set; }
    }
