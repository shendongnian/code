    var query = session.CreateCriteria(typeof(Media), "m")
      .Add(Projections.GroupProperty("m.Uid"))
      .Add(Projections.Property(), "m");
      .Add(Restrictions.NotEq("m.Uid", 0));
    
    // dynamically add filters
    if (filterProductLines)
    {
      query
        .CreateCriteria("m.Productlines", "p")
        .Add(Restrictions.Eq("p.Uid", productLines));
    }
    // more dynamic filters of this kind follow here...
    IList<object[]> results = query.List<object[]>();
    // the second column in the result is the media.
    IList<Media> medias = results.Select(x => x[1]);
