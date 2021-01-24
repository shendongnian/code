    public interface IUser
    {
        [JsonProperty("id")]
        string DocumentId { get; set; }
        [JsonProperty("created")]
        DateTimeOffset Created { get; set; }
        [JsonProperty("modified")]
        DateTimeOffset Modified { get; set; }
        [JsonProperty("email")]
        string Email { get; set; }
        ...
    }
