    public class RegistrationService: IRegistrationService
    {
        public RegistrationService(IRepository<User> userRepo)
        {
            m_userRepo = userRepo;
        }
    
        private IRepository<User> m_userRepo;
    
        public void Register(User user)
        {
            // add user, etc with m_userRepo
        }
    }
