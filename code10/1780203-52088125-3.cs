    public class UserData : BaseData<UserMessage>
    {
    	[JsonProperty("user_id")]
    	public int UserId { get; set; }
    }
    
    public class UserMessage
    {
    	[JsonProperty("id")]
    	public int Id { get; set; }
    	[JsonProperty("message")]
    	public string Message { get; set; }
    }
    
