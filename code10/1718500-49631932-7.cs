    public interface IUserData
    {
    	User GetUser(uint id);
    	User ByName(string username);
    }
    
    public class User
    {
    	public string name { get; set; }
    }
    
    [AuthorizedUserData]
    public class UserData : MarshalByRefObject,IUserData
    {
    	public User GetUser(uint id)
    	{
    		return new User() { };
    	}
    	public User ByName(string username)
    	{
    		return new User() { };
    	}
    }
    IUserData user = ProxyFactory.GetInstance<IUserData, UserData>();
    user.ByName("1");
