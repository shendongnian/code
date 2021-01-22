    public class Repository
    {
        public IList<T> WrapQueryInSession<T>(Func<ISession,IList<T> query)
        {
            using(var session = GetSession())
            using(var tx = session.BeginTransaction())
            {
                 var items = query(session);
                 //Handle exceptions transacitons etc.
                 return items;
            }
         }
     }
