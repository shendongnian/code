    public interface IUsersRepository
        {
            int GetUsersCount();
        }
        public class UsersRepository : IUsersRepository
        {
            private readonly EntityFrameworkContext _context;
            public UsersRepository(EntityFrameworkContext context)
            {
                _context = context;
            }
            public int GetUsersCount()
            {
                return _context.Users.Count();
            }
        }
