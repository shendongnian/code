    public class MyUserManager<TUser> : UserManager<TUser>
    {
        public async Task<TUser> FindByEmailAsync(string email, int customerId)
        {
            //your code.
        }
    }
