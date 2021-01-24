    public class User : IUser
    {
        [JsonProperty("id")]
        public string DocumentId { get; set; } = "";
        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }
        [JsonProperty("modified")]
        public DateTimeOffset Modified { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
      
        ...
    }
