    public class RegistrationService: IRegistrationService
    {
        public void Register(User user)
        {
            this(user, new UserRepository());
        }
        public void Register(User user, IRepository<User> userRepository)
        {
            // add user, etc
        }
    }
