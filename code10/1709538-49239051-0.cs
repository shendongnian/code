    //Create a class matching response object
    public class ResponseItem
    {
       public int item {get;set;}
       public string Name {get;set;}
    }
 
    var responseJson = utils.RemoveJsonOuterClass("GetTable", 
    JsonConvert.DeserializeObject(@return).ToString();
    
    var responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<List<ResponseItem, ResponseItem>>>()responseJson);
