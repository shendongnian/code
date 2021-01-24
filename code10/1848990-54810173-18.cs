    public class DataContext : DbContext, IDataContext
    {
        public DataContext(IAuditHelper auditHelper, DbContextOptions options)
            : base(options)
        {
            AuditHelper = auditHelper;
        }
        public IAuditHelper AuditHelper { get; private set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            AuditHelper.LogMyChangesToDatabase();
            return base.SaveChangesAsync(true, cancellationToken);
        }
        ...
    }
    public interface IDataContext : IDisposable
    {
        IAuditHelper AuditHelper { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        ...
    }
    public class UniversityDbContext : DataContext
    {
        public UniversityDbContext(IAuditHelper auditHelper, DbContextOptions options)
            : base(auditHelper, options)
        {
        }
    }
