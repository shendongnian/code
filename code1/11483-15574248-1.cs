    public class TestBase
    {
        [TestInitialize]
        public virtual void Initialize()
        {
            NHibernateBootstrapper.InitializeSession();
            var transaction = SessionFactory.Current.GetCurrentSession().BeginTransaction();
        }
        [TestCleanup]
        public virtual void Cleanup()
        {
            var currentSession = SessionFactory.Current.GetCurrentSession();
            if (currentSession.Transaction != null)
            {
                currentSession.Transaction.Rollback();
                currentSession.Close();
            }
            NHibernateBootstrapper.CleanupSession();
        }
    }
