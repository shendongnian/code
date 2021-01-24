    public async Task<Data> GetEmployee(string instance)
    {
        string responsedata = "   {\"@odata.context\":\"https://science.com/odata/$metadata#EMPLOYEE\",\"value\":[{\"Id\":5000004,\"Name\":\"Account\"}]}";
    
        return JsonConvert.DeserializeObject<Data>(responsedata);
    }
    
    public class Data
    {
        [JsonProperty("@odata.context")]
        public string ODataContext { get; set; }
        
        public Value[] Value { get; set; }
    }
    
    public class Value
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
