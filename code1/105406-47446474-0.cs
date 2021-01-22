    public class UserRepository : IUserRepository
    {
        [DoNotSelect] // This constructor will be ignored by Windsor
        public UserRepository(IObjectContext objectContext)
        {
            // ...
        }
        public UserRepository(IObjectContextFactory factory)
            : this(factory.CreateObjectContext()) {}
    }
