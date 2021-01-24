    public class AllowedValue
    {
        [JsonProperty("self")]
        public string Self { get; set; }
        [JsonProperty("iconUrl")]
        public string IconUrl { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
    }
    public class Priority
    {
        [JsonProperty("allowedValues")]
        public IList<AllowedValue> AllowedValues { get; set; }
    }
    public class AllowedValue
    {
        [JsonProperty("self")]
        public string Self { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
    public class Components
    {
        [JsonProperty("allowedValues")]
        public IList<AllowedValue> AllowedValues { get; set; }
    }
    public class Fields
    {
        [JsonProperty("priority")]
        public Priority Priority { get; set; }
        [JsonProperty("components")]
        public Components Components { get; set; }
    }
    public class Issuetype
    {
        [JsonProperty("fields")]
        public Fields Fields { get; set; }
    }
    public class Project
    {
        [JsonProperty("issuetypes")]
        public IList<Issuetype> Issuetypes { get; set; }
    }
    public class RootObject
    {
        [JsonProperty("projects")]
        public IList<Project> Projects { get; set; }
    }
