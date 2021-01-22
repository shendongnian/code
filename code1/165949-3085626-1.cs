    IList results = session.CreateCriteria(typeof(MyType))
        .Add(Restrictions.In("A", new [] {1, 6}))
        .Add(Restrictions.Disjunction()
            .Add.Restrictions.Not(Restrictions.Like("B", "Value%"))
            .Add.Restrictions.Not(Restrictions.Like("B", "ValueII%")))
        .List<MyType>();
