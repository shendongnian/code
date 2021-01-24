	public class BaseInput
	{       
	    [JsonProperty(PropertyName = "partnerId")]
	    public  int partnerId { get; set; }
	    
	    [JsonProperty(PropertyName = "method")]
	    public  string method { get; set; }
	    [JsonProperty(PropertyName = "hashcode")]
	    public string hashCode { get; set; }
	    [JsonProperty(PropertyName = "accountid")]
	    public int accountId { get; set; }
	}
	
