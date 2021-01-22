    using (ISession session = sessionFactory.OpenSession())
    using (ITransaction tx = session.BeginTransaction())
    {
    for (int i = 0; i < 100000; i++)
    {
    Customer customer = new Customer(.....);
    session.Save(customer);
    }
    tx.Commit();
    }
