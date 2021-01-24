    public interface IUserRepository : IRepository<ApplicationUser>
    {
        void DoTheThing();
    }
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext) {}
        public void DoTheThing()
        {
        }
    }
