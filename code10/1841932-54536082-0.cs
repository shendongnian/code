    public class Response
    {
    	public ResponseResult Result{ get; set; }
    }
    public class ResponseResult
    {
    	public ResponseResultAddress[] Address_Components{ get; set; }
    }
    
    public class ResponseResultAddress
    {
    	public string Long_Name { get; set; }
    	public string Short_Name { get; set; }
    	public string[] Types { get; set; }
    }
    
    
    var data = JsonConvert.DeserializeObject<Response>(result);
    var street = data.Result.Address_Components.FirstOrDefault(item => item.Long_name == "90" && item.Types.Contains("street_number"));
