    public class CInfoWithEvents
    {
        [JsonProperty(PropertyName = "CInfo")]
        public CInfo  {get; set;}
    
        [JsonProperty(PropertyName = "Events")]
        public List<Event> { get; set; }
    }
