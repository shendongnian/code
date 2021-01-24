    public class EFUserrolesRepository : IUserrolesRepository
    {
        private ApplicationDbContext context;
        public EFUserrolesRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Userrole> Userroles => context.Userrole;
      
    }
