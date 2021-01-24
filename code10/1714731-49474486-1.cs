    public class UserRole : IdentityUserRole<Guid>
    {
    	private User _user;
    	private Role _role;
    	
    	private UserRole()
    	{
    	}
    	
    	public UserRole(User user, Role role)
    	{
    		_user = user;
    		_role = role;
    	}
    	
    	public virtual User User => _user;
    	public virtual Role Role => _role;
    }
