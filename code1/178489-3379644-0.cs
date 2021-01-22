    public class Repository
    {
        public void Add<T>(T entity)
        {
            using(var session = GetSession())
            using(var tx = session.BeginTransaction())
            {
                 session.Save(entity)
                 //Transaction handling etc.
            }
        }
        .... //repeat ad nasseum :-)
    }
