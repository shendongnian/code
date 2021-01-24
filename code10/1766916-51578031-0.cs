    void Main()
    {
        string testJson = @"{""onlineRequest"":{""MobileNumber"":""75484568"",""ProductNo"":""100"",""JsonFile"":{""dropdown"":[{""@para-id"":""2572"",""@new-code"":"""",""@text"":""This is first dropdown"",""option"":[{""@text"":""Option 1"",""@value"":""0""}]},{""@para-id"":""2584"",""@new-code"":"""",""@text"":""This is second dropdown"",""option"":[{""@text"":""Excellent"",""@value"":""2""}]},{""@para-id"":""2575"",""@new-code"":"""",""@text"":""This is third dropdown"",""option"":[{""@text"":""Not Available"",""@value"":""1""}]}]}}}";
    
        Response response = JsonConvert.DeserializeObject<Response>(testJson);
        
        var dropdowns = response.OnlineRequest.JsonFile;
        
        string json = JsonConvert.SerializeObject(dropdowns, Newtonsoft.Json.Formatting.Indented);
        
        Console.WriteLine(json);
    }
    
    
    public class Option
    {
    
        [JsonProperty("@text")]
        public string Text { get; set; }
    
        [JsonProperty("@value")]
        public string Value { get; set; }
    }
    
    public class Dropdown
    {
    
        [JsonProperty("@para-id")]
        public string ParaId { get; set; }
    
        [JsonProperty("@new-code")]
        public string NewCode { get; set; }
    
        [JsonProperty("@text")]
        public string Text { get; set; }
    
        [JsonProperty("option")]
        public IList<Option> Option { get; set; }
    }
    
    public class JsonFile
    {
    
        [JsonProperty("dropdown")]
        public IList<Dropdown> Dropdown { get; set; }
    }
    
    public class OnlineRequest
    {
    
        [JsonProperty("MobileNumber")]
        public string MobileNumber { get; set; }
    
        [JsonProperty("ProductNo")]
        public string ProductNo { get; set; }
    
        [JsonProperty("JsonFile")]
        public JsonFile JsonFile { get; set; }
    }
    
    public class Response
    {
    
        [JsonProperty("onlineRequest")]
        public OnlineRequest OnlineRequest { get; set; }
    }
