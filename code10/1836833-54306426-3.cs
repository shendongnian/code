    class MainObj
    {
        [JsonExtensionData]
        public Dictionary<string, JToken> DynamicData { get; set; }
    
        [JsonIgnore]
        public Dictionary<string, ChildObj> ParsedData
        {
            get
            {
                return DynamicData.ToDictionary(x => x.Key, y => y.Value.ToObject<ChildObj>());
            }
        }
    
        public int result_code { get; set; }
        public string result_message { get; set; }
        public string result_output { get; set; }
    }
    
    public class ChildObj
    {
        public string id { get; set; }
        public string name { get; set; }
        public string cdate { get; set; }
        public string _private { get; set; }
        public string userid { get; set; }
        public int subscriber_count { get; set; }
    }
