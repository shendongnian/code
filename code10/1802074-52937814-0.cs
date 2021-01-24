    public class MyDbContext : DbContext {
        private readonly IAuditHelper auditHelper;
    
        public MyDbContext(DbContextOptions<MyDbContext> options, IAuditHelper auditHelper)
            : base(options) {
            this.auditHelper = auditHelper;
        }
    
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken)) {
            var audits = auditHelper.AddAuditLog(base.ChangeTracker);
            return base.SaveChangesAsync(true, cancellationToken);
        }
    }
