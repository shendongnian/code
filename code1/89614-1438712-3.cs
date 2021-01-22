    var subquery = DetachedCriteria.For(typeof(Media), "m")
      .Add(Projections.GroupProperty("m.Uid"))
      .Add(Restrictions.NotEq("m.Uid", 0));
    // add filtering
    var query = session.CreateCriteria(typeof(Media), "outer")
      .Add(Subqueries.PropertyIn("outer.Uid", subquery));
  
    IList<Media> results = query.List<Media>();
