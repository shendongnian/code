        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {       
        private readonly HttpContext httpContext;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor contextAccessor)
            : base(options)
        {
            this.httpContext = contextAccessor.HttpContext;
        }       
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public override EntityEntry<TEntity> Add<TEntity>(TEntity entity)
        {
            DatabaseEntity dbEntity = (entity as DatabaseEntity);
            var userName = httpContext.User.Identity.Name;
            if (dbEntity != null)
            {
                dbEntity.Created = DateTime.Now;
                dbEntity.Creator = userName == null ? null : ApplicationUser.Where(user => user.UserName == userName).FirstOrDefault();
            }
            return base.Add(entity);    
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);            
        }        
    }
