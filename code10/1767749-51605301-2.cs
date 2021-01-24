    public class UserContext : DbContext {
        public UserContext(DbContextOptions<UserContext> options): base(options) {
        }
        public virtual DbSet<User> tblUser { get; set; }
    }
