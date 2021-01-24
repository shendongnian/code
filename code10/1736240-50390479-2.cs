    public class UserRole : IdentityUserRole<int>
    {
    	public int AccountId
    	{
    		get => base.UserId;
    		set => base.UserId = value;
    	}
    
    	public User Account { get; set; }
    	public Role Role { get; set; }    // Addition
    }
