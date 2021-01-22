      public class ApplicationEfRepository : EFRepositoryBase      
      {
         public new class Dependency : EFRepositoryBase.Dependency
         {
             public Dependency(
                DbContext dbContext,
                IAuditFactory auditFactory)
            {
                DbContext = dbContext;
                AuditFactory = auditFactory;
            }
         }
          public ApplicationEfRepository(
              Dependency dependency)
              : base(dependency)
          { }
       }
