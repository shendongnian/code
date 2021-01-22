    ICriteria query = session.CreateCriteria(typeof(MyType));
    query.Add(Restrictions.In("A", new [] {1, 6}))
    Disjunction disjunction = Restrictions.Disjunction();
    foreach (var value in values) {
        disjunction.Add(Restrictions.Not(Restrictions.Like(value, "Value%")));
        disjunction.Add(Restrictions.Not(Restrictions.Like(value, "ValueII%")));
    }
    query.Add(disjunction);
    
    IList results = query.List<MyType>();
