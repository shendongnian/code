    public partial class MyContext : DbContext
    {
        // Reference to the name of the current user.
        private readonly string _userName;
        public MyContext(DbContextOptions<MyContext> options, IHttpContextAccessor httpContext)
            : base(options)
        {
            // Save the name of the current user so MyContext knows
            // who it is. The advantage is that you won't need to lookup
            // the User on each save changes.
            _userName = httpContext.HttpContext.User.Identity.Name;
        }
        public virtual DbSet<Host> Host { get; set; }
        // You'll only need to override this, unless you are
        // also using non-async SaveChanges.
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateEntries();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        // You can move this to another partial class.
        private void UpdateEntries()
        {
            // Modified
            var modified = ChangeTracker.Entries().Where(v => v.State == EntityState.Modified && typeof(IBaseEntity).IsAssignableFrom(v.Entity.GetType())).ToList();
            modified.ForEach(entry =>
            {
                ((IBaseEntity)entry.Entity).LastDateModified = DateTime.UtcNow;
                ((IBaseEntity)entry.Entity).LastDateModifiedBy = _userName;
            });
            // Added
            var added = ChangeTracker.Entries().Where(v => v.State == EntityState.Added && typeof(IBaseEntity).IsAssignableFrom(v.Entity.GetType())).ToList();
            added.ForEach(entry =>
            {
                ((IBaseEntity)entry.Entity).DateCreated = DateTime.UtcNow;
                ((IBaseEntity)entry.Entity).DateCreatedBy = _userName;
                ((IBaseEntity)entry.Entity).LastDateModified = DateTime.UtcNow;
                ((IBaseEntity)entry.Entity).LastDateModifiedBy = _userName;
            });
        }
        // ...
    }
