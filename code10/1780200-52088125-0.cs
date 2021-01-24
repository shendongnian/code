    public abstract class Response<TData>
    {
    	[JsonProperty("data")]
    	public TData Data { get; set; }
    }
    
