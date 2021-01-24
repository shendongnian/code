    [DataContact]
    public class ADesired
    {
    	[DataMember]
    	public B Inner {get; set;}
    	public string InnerAsJsonString => Newtonsoft.Json.JsonConvert.SerializeObject(Inner);
    }
