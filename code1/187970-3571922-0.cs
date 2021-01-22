    BasicUser user = null;
    using (ISession session = sessionFactory.OpenSession())
    {
        IQuery query = session.CreateQuery("From BasicUser user where user.Email=?");
        query.SetString(0, email);
        query.SetMaxResults(1);
        IList<BasicUser> results = query.List<BasicUser>();
        if (results.Count > 0)
            user = results[0];
    }
    return user;
