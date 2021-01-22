    // the thread-safe singleton
    public sealed class SessionManager
    {
        ISession session;
        SessionManager()
        {
            ISessionFactory factory = Setup.CreateSessionFactory();
            session = factory.OpenSession();
        }
        internal ISession GetSession()
        {
            return session;
        }
        public static SessionManager Instance
        {
            get
            {
                return Nested.instance;
            }
        }
        class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }
            internal static readonly SessionManager instance = new SessionManager();
        }
    }
    // the generic Dao that works with your POCO's
    public class Dao<T>
        where T : class
    {
        ISession m_session = null;
        private ISession Session
        {
            get
            {
                // lazy init, only create when needed
                return m_session ?? (m_session = SessionManager.Instance.GetSession());
            }
        }
        public Dao() { }
        // retrieve by Id
        public T Get(int Id)
        {
            return Session.Get<T>(Id);
        }
        // get all of your POCO type T
        public IList<T> GetAll(int[] Ids)
        {
            return Session.CreateCriteria<T>().
                Add(Expression.In("Id", Ids)).
                List<T>();
        }
        // save your POCO changes
        public T Save(T entity)
        {
            using (var tran = Session.BeginTransaction())
            {
                Session.SaveOrUpdate(entity);
                tran.Commit();
                Session.Refresh(entity);
                return entity;
            }
        }
        public void Delete(T entity)
        {
            using (var tran = Session.BeginTransaction())
            {
                Session.Delete(entity);
                tran.Commit();
            }
        }
        // if you have caching enabled, but want to ignore it
        public IList<T> ListUncached()
        {
            return Session.CreateCriteria<T>()
                .SetCacheMode(CacheMode.Ignore)
                .SetCacheable(false)
                .List<T>();
        }
        // etc, like:
        public T Renew(T entity);
        public T GetByName(T entity, string name);
        public T GetByCriteria(T entity, ICriteria criteria);
