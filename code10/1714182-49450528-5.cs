    public class UserRepository : IUserRepository
    {
       private readonly IDbContext _context;
    
       public UserRepository(IDbContext context)
       {
          _context = context;
       }
    }
