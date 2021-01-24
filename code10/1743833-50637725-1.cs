    public class Authentication
    {
        public string usertoken { get; set; }
        public int expires_sec { get; set; }
        public string user { get; set; }
    	[JsonProperty (".expired")]
        public string expired { get; set; }
    }
