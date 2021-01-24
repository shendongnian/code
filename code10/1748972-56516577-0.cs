    public class CustomUserStore : UserStore<IdentityUser>
    {
        public CustomUserStore(ApplicationDbContext context)
            : base(context)
        {
            AutoSaveChanges = false;
        }
    }
