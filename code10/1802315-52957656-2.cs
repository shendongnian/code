    public class ReconciliationUnitOfWork : UnitOfWork<ReconciliationDbContext>
    {
      public ReconciliationUnitOfWork(ReconciliationDbContext context)
        : base(context)
      { /* ... */ }
    }
