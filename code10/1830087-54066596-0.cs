    public class UsersDao : GenericDao<UsersDo>, IUsers
    {
         public UsersDao(DataContext context) : base (context) {}
         ...
    }
