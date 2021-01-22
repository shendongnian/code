    namespace MyApp.Model
    {
        public interface IUserRepository 
        {
            User Get(int userId);
            ...
        }
        public class UserRepository : IUserRepository
        {
            public User GetById(int userId)
            {
                using (var dataContext = MyDbContext())
                {
                    var user = dataContext.Users.Find(u => u.UserId == userId);
                    var decryptedSSNResult = dataContext.Decrypt(u.SSN);
                    user.DecryptedSSN = decryptedSSNResult.FirstOrDefault();
                    return user;
                }
            }
        }
    }
