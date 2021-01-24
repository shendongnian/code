    public class CInfoWithEvents : CInfo
    {        
        [JsonProperty(PropertyName = "Events")]
        public List<Event> { get; set; }
    }
