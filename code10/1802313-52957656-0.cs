    public class ReconciliationUnitOfWork : UnitOfWork<ReconciliationDbContext>
    {
      public ReconciliationUnitOfWork([KeyFilter(ContextKey.Recon)]IDbContext context)
      { /* ... */ }
    }
