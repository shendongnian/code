    public class Foo : HibernateDaoSupport
    {
        public void Bar()
        {
            using (var session = SessionFactory.OpenStatelessSession())
            {
                // do something with the stateless session
            }
        }
    }
