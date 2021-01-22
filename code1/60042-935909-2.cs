    public class RegistrationService: IRegistrationService
    {
        public void Register(User user)
        {
            this(user, IoC.Resolve<IRepository<User>>());
        }
        public void Register(User user, IRepository<User> userRepository)
        {
            // add user, etc
        }
    }
