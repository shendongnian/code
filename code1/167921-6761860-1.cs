    ICriteria criteria =  session.CreateCriteria<A>();
    criteria.CreateAlias("MyList", "b", JoinType.LeftOuterJoin)
    criteria.Add(Restrictions.Lt("b.Date", myDate));
    criteria.SetResultTransformer(new DistinctRootEntityResultTransformer());
    criteria.List<A>();
