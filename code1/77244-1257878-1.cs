    public class UserRep : IUserRepository
    {
        public UserRep(string connectionStringName)
        {
            // user the conn when building your datacontext
        }
    
        public User GetById(int id)
        {
            var context = new DataContext(_conString);
            // obviously typing this freeform but you get the idea...
            var user = // linq stuff
            return user;
        }
        public IQueryable<User> FindAll()
        {
            var context = // ... same pattern, delayed execution
        }
    }
