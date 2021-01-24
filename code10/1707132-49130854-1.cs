    public class Root
    {
        [JsonProperty(PropertyName ="gameid")]
        public int GameId { get; set; }
    
        [JsonProperty(PropertyName = "userid")]
        public int UserId { get; set; }
    
        [JsonProperty(PropertyName = "actions")]
        public List<Action> Actions { get; set; }
        ... other properties ...
    }
