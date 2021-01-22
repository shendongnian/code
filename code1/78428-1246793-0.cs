    List<Comments> comments = session.CreateCriteria<BlogPost>()
                .Add(Restrictions.Eq("Id", 1))
                .CreateAlias("Comments", "c")
                .Add(Restrictions.Eq("c.DatePosted", new DateTime(2009, 8, 1)))
                .list();
