    public partial class ErrorResponse
    {
        [JsonProperty("error")]
        public Error Error { get; set; }
    }
    public partial class Error
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
