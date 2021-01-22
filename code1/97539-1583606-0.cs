    using (ISession session = NHibernateHelper.GetCurrentSession())
    {
        using (ITransaction transaction = session.BeginTransaction())
        {
            foreach (var player in players)
            {
                session.Save(player);
            }
            transaction.Commit();
        }
    }
