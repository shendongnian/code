    public class Data
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("parent_crumbs")]
        public List<string> ParentCrumbs { get; set; }
    }
