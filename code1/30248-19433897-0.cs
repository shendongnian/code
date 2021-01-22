 public void UpdateProject(Project proj)
 {
    ISessionFactory SessionFactory;
    ISession session = SessionFactory.OpenSession();
    using (ITransaction transaction = session.BeginTransaction())
    {
      session.Update(proj);
      transaction.Commit();
    }
 }
