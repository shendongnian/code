    public abstract class BaseData<TMessage>
    {
    	[JsonProperty("success")]
    	public bool Success { get; set; }
    	[JsonProperty("message")]
    	public TMessage Message { get; set; }
    }
    
