    public interface IDbContext {
        void CommitChanges();
        IDisposable BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
 
    public class DbContext : IDbContext {
        private readonly ISession _session;
        public DbContext(ISession session)
        {
            Check.RequireNotNull<ISession>(session);
            _session = session;
        }
        public void CommitChanges() { _session.Flush(); }
        public IDisposable BeginTransaction() { return _session.BeginTransaction(); }
        public void CommitTransaction() { _session.Transaction.Commit(); }
        public void RollbackTransaction() { _session.Transaction.Rollback(); }
    }
