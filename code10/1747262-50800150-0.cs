    public class SharePointSiteObject
    {
        [JsonProperty("createdDateTime")]
        public string CreatedDate { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("lastModifiedDateTime")]
        public string LastModified { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("webUrl")]
        public string WebUrl { get; set; }
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
        [JsonProperty("createdBy")]
        public user CreatedBy { get; set; }
        [JsonProperty("lastModifiedBy")]
        public user ModifiedBy { get; set; }
    }
