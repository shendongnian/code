    class Response
    {
    	Data data { get; set; }
    }
    
    public abstract class Data
    {
    	bool Success { get; set; }
    	public abstract Response CreateDeserializationModelSchema();
    }
    
    public class UserData : Data
    {
    	public bool Success { get; set; }
    	public List<int> UpdatedIds { get; set; }
    	public List<int> NotUpdatedIds { get; set; }
    	public override Response CreateDeserializationModelSchema()
    	{
    		return new Response
    		{
    			Data = new UserData()
    		};
    	}
    	public static UsersData GetContent(Response response)
    	{
    		if (response.Data.GetType() == typeof(UsersData))
    			return (UsersData)response.Data;
    		else
    			throw new FormatException("Response not in the correct format to parse into UpdateUsersStatusResponse");
    	}
    }
    
    class UsersDataConverter : CustomCreationConverter<Response>
    {
    	public override Response Create(Type objectType)
    	{
    		return new UsersData().CreateDeserializationModelSchema();
    	}
    }
    
    public class HowToUseIt
    {
    	public void Use()
    	{
    		Response resp = JsonConvert.DeserializeObject<Response>(jsonResponse.ToString(), new UserDataConverter());
    		UserData u = UserData.GetContent(resp)
    	}
    }
