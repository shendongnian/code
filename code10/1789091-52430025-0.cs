    public class ApplicationUserManager : UserManager<ApplicationUser, int>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser, int> store, IIdentityMessageService emailService)
            : base(store)
        {
            this.EmailService = emailService;
        }
    ...
