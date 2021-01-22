    using (ISession session = ...)
    using (ITransaction tx = session.BeginTransaction())
    {
        Foo result = session.Get<Foo>(id);
    
        tx.Commit();
    }
    // could still fail in case of lazy loaded references
    Console.WriteLine(result.Name);
