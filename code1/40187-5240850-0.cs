    class TestFixture {
        static ISessionFactory factory = CreateMyFactorySomehowHere();
        ISession session;
        ITransaction tx;
        public void Setup ()
        {
            session = factory.OpenSession ();
            tx = session.BeginTransaction ();
        }
        public void Cleanup ()
        {
            tx.Rollback ();
            tx.Dispose ();
            session.Close ();
        }
        public void TestAMappingForSomething ()
        {
            var spec = new PersistenceSpecification<Something> (session);
            spec.VerifyTheMappings ();
        }
    }
