    public class AuthenticationResponse
    {
            [JsonProperty("id")]
            public string id { get; set; }
            [JsonProperty("result")]
            AuthenticationResult res { get; set; }
    }
    
    public class AuthenticationResult
    {
            [JsonProperty("sessionId")]
            string sessionId { get; set; }
            [JsonProperty("personType")]
            int personType { get; set; }
            [JsonProperty("personId")]
            int personId { get; set; }
            [JsonProperty("klasseId")]
            int klasseId { get; set; }
    }
