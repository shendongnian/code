    using (var session = OpenSession())
    using (var tx = s.BeginTransaction())
    {
      session
        .CreateQuery("delete from Whatever where IsDelete = true")
        .ExecuteUpdate();
      tx.Commit();
    }
