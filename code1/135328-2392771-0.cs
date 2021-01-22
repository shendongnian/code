    public class Foo
    {
        IExceptionManager _em;
        IDatabase _db;
        IServiceAgent _sa; // custom made service agent for accessing some other web service
        public Foo(IExceptionManager em, IDatabase db, IServiceAgent _sa)
        {
            _em = em;
            _db = db;
            _sa = sa;
        }
    }
