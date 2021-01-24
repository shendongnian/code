    /// <summary>
    /// Class representing the JSON
    /// </summary>
    public class Root
    {
        [JsonProperty("User")]
        public User SomeUser { get; set; }
    
        public class User
        {
            [JsonProperty("username")]
            public string UserName { get; set; }
            [JsonProperty("email")]
            public string EMail { get; set; }
            [JsonProperty("ref_id")]
            public string ReferenceId { get; set; }
            // etc.
        }
    }
