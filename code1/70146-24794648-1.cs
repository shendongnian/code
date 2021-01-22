     public class WorklistSortColumn
      {
        [JsonProperty(PropertyName = "field")]
        public string Field { get; set; }
        [JsonProperty(PropertyName = "dir")]
        public string Direction { get; set; }
        [JsonIgnore]
        public string SortOrder { get; set; }
      }
  
