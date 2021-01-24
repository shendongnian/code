    [HttpPost]
    public MyModel GetSomething([FromBody]RequestModel model)
    {
        return GetMyModel(model.uid);
    }
    
    public class RequestModel
    {
    	public System.Nullable<System.Guid> uid { get; set; }
    }
