    if (Groups!= null && Groups.Count > 0)
    {
        var items = Groups.ConvertAll(i => i.Id).ToArray();
        criteria.CreateCriteria("Groups", "g", JoinType.LeftOuterJoin);
        criteria.Add(Restrictions.In("g.Id", items));
    }
