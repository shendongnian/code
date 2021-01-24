    public class WorkItemAtrr
    {
        [JsonProperty("id")]
        public int id;
        [JsonProperty("rev")]
        public int rev;
        [JsonProperty("fields")]
        public Dictionary<string, string> fields;
        [JsonProperty("_links")]
        public Dictionary<string, Link> _links;
        [JsonProperty("relations")]
        public List<Relation> relations;
        [JsonProperty("url")]
        public string url;
    }
    public class Link
    {
        [JsonProperty("href")]
        public string href;
    }
    public class Relation
    {
        [JsonProperty("rel")]
        public string rel;
        [JsonProperty("url")]
        public string url;
        [JsonProperty("attributes")]
        public RelationAttribute attributes;
    }
    public class RelationAttribute
    {
       [JsonProperty("comment")]
       public string comment = "";
       [JsonProperty("isLocked")]
       public bool isLocked;
    }
