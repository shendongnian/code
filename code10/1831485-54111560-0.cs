    public partial class MyDbContext : DbContext
    {
        private readonly IUserResolverService _userResolverService;
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            _userResolverService = this.GetService<IUserResolverService>();
        }
    }
