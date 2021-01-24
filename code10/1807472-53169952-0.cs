    public class Tags
    {
        [JsonProperty("Associated Team")]   //this one changed
        public string associatedTeam { get; set; }
        public string description { get; set; }
        [JsonProperty("Point of Contact")]  //this one too
        public string pointOfContact { get; set; }
    }
