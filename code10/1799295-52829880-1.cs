    public class Response
    {
        public string statusCode { get; set; }
        public string status { get; set; }
        [JsonExtensionData]
        public Dictionary<string, JToken> data;
    }
    
