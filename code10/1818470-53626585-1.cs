    class MyJson
    {
        public string fixedName1 {get;set;}
        public string fixedName2 {get;set;}
    
        [JsonExtensionData]
        public Dictionary<string, JToken> randomNames {get;set;}
    }
