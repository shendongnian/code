    using Newtonsoft.Json;
    
    [JsonObject]
    public class NewRentalDto
    {
        [JsonProperty]
        public int CustomerId { get; set; }
    
        [JsonProperty]
        public List<int> MovieIds { get; set; }
    }
