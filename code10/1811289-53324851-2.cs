    public class MyCustomUserStore<TUser> : Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser>, IUserLdapStore<TUser>
    	where TUser : IdentityUser<string>, new()
    {
    	public MyCustomUserStore(DbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }
    
    	public Task<string> GetDistinguishedNameAsync(TUser user)
    	{
    		return Task.FromResult(string.Empty);
    	}
    }
