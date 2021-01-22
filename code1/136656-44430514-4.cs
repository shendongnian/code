     public abstract class EFRepositoryBase 
     {
        public class Dependency
        {
            public DbContext DbContext { get; }
            public IAuditFactory AuditFactory { get; }
             public Dependency(
                DbContext dbContext,
                IAuditFactory auditFactory)
            {
                DbContext = dbContext;
                AuditFactory = auditFactory;
            }
        }
        protected readonly DbContext DbContext;        
        protected readonly IJobariaAuditFactory auditFactory;
        protected EFRepositoryBase(Dependency dependency)
        {
            DbContext = dependency.DbContext;
            auditFactory= dependency.JobariaAuditFactory;
        }
      }
