    namespace IdentityDemo.Models.ModelView
    {
        public class UserMv
        {
    public UserMv(IdentityUser aus, List<string> userRoles)
            {
                UserId = aus.Id;
                UserName = aus.UserName;
                RolesHeld = userRoles; 
                Email = aus.Email;
                EmailConfirmed = aus.EmailConfirmed;
                LockoutEnabled = aus.LockoutEnabled;
                AccessFailedCount = aus.AccessFailedCount;
            }
    }
