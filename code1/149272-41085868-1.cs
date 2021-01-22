    static public class Repository
    {
        //You can wrap the interface (proxy) here if you need...
        static private readonly IRepository m_Repository = MyDIFactory.Import<IRepository>();
        static public IQueryable<T> Query<T>()
            where T : class
        {
            return Repository.m_Repository.Query<T>();
        }
    }
