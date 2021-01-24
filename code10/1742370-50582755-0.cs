    public class Company
    {
        [JsonProperty(PropertyName = "guid")]
        public Guid Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        
        [JsonProperty(PropertyName = "rating")]
        public int Rating { get; set; }
        [JsonProperty(PropertyName = "rating_date")]
        public DateTime Rating_date { get; set; }
     }
