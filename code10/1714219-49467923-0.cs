    public interface IInitializationService
    {
        void Seed();
    }
    public class InitializationService : IInitializationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public InitializationService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public void Seed()
        {
            // more code
        }
    }
