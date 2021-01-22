    public interface IUserRepository
    {
        IUserData GetData(string userName);
    }
    public class UserRepository 
        : IUserRepository
    {
        // The old method is not touched.
        public UserData GetData(string userName)
        {
            ...    
        }
        // Explicitly implement the interface method.
        IUserData IUserRepository.GetData(string userName)
        {
            return this.GetData(userName);
        }
    }
