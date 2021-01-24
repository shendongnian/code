    //Create a class matching response object
    public class ResponseItem
    {
        [JsonProperty("item")]
        public int Item { get; set; }
        public string Name { get; set; }
    }
 
    var responseJson = utils.RemoveJsonOuterClass("GetTable", 
    JsonConvert.DeserializeObject(@return).ToString();
    
    var responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<List<ResponseItem, ResponseItem>>>(responseJson);
