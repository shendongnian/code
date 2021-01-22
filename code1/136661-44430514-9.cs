      public class ApplicationEfRepository : EFRepositoryBase      
      {
         public new class Dependency : EFRepositoryBase.Dependency
         {
             public IConcreteDependency ConcreteDependency { get; }
             
             public Dependency(
                DbContext dbContext,
                IAuditFactory auditFactory,
                IConcreteDependency concreteDependency)
            {
                DbContext = dbContext;
                AuditFactory = auditFactory;
                ConcreteDependency = concreteDependency;
            }
         }
          
          IConcreteDependency _concreteDependency;
          public ApplicationEfRepository(
              Dependency dependency)
              : base(dependency)
          { 
            _concreteDependency = dependency.ConcreteDependency;
          }
       }
