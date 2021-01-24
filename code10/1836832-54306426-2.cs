    class MainObj
    {
        [JsonExtensionData]
        public Dictionary<string, JToken> DynamicData { get; set; }
        public int result_code { get; set; }
        public string result_message { get; set; }
        public string result_output { get; set; }
    }
    
