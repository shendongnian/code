    public class MyCustomUserStore<TUser> : Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser>, IUserLdapStore<TUser>
        where TUser : IdentityUser<string>, new()
    {
        //constructor goes here....
    
        public Task<string> GetDistinguishedNameAsync(TUser user)
        {
            return Task.FromResult(string.Empty);
        }
    }
