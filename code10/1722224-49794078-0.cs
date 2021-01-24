    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
    	public ApplicationUserManager(IUserStore<ApplicationUser> store)
    		: base(store)
    	{
    		PasswordHasher = new AspNetCorePasswordHasher();
    	}
    	...
    }
