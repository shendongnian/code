    public class SuccesType
    {
        [JsonProperty]
        public string access_token { get; set; }
        [JsonProperty]
        public string token_type { get; set; }
    }
    public class ServerError
    {
        [JsonProperty]
        public string message { get; set; }
        [JsonProperty]
        public string reason { get; set; }
        [JsonProperty]
        public string details { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            string Jsonstr = @"{ ""accesstoken"":""test access token"", ""token_type"":""token test"" }";
            bool testdeseralize = DeSerializeResponse<SuccesType>(Jsonstr);
        }
        private static bool DeSerializeResponse<T>(string RespBody)
        {
            JsonSerializerSettings testSettings = new JsonSerializerSettings();
            testSettings.MissingMemberHandling = MissingMemberHandling.Error;
            try
            {
                var responsedBody = JsonConvert.DeserializeObject<T>(RespBody, testSettings);
            }
            catch(JsonSerializationException ex)
            {
                return false;
            }
            return true;
        }
    }
