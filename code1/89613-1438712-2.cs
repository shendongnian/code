    var query = session.CreateCriteria(typeof(Media), "m")
      .Add(Projections.GroupProperty("m"))
      .Add(Restrictions.NotEq("m.Uid", 0));
    
    // dynamically add filters
    if (filterProductLines)
    {
      query
        .CreateCriteria("m.Productlines", "p")
        .Add(Restrictions.Eq("p.Uid", productLines));
    }
    // more dynamic filters of this kind follow here...
    IList<Media> results = query.List<Media>();
