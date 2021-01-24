    public class UpdateCheck
    {
        [JsonProperty("UpdatesAvailable")]
        public bool UpdatesAvailable { get; set; }
    
        [JsonProperty("LinkOfNewVersion")]
        public string LinkOfNewVersion { get; set; }
    }
