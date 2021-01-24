    public class RestApiExceptionContainer
    {
        [JsonProperty("id")]
        public int id;
        [JsonProperty("innerException")]
        public string innerException;
        [JsonProperty("message")]
        public string message;
        [JsonProperty("typeName")]
        public string typeName;
        [JsonProperty("typeKey")]
        public string typeKey;
        [JsonProperty("errorCode")]
        public int errorCode;
        [JsonProperty("evenId")]
        public int eventId;
    }
