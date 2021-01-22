    using (ISession session = ...)
    using (ITransaction tx = session.BeginTransaction())
    {
        Foo result = session.Load<Foo>(id);
        // should always work fine
        Console.WriteLine(result.Name);
        tx.Commit();
    }
