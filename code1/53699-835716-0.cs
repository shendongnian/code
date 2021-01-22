    DetachedCriteria c = DetachedCriteria.For<Record>()
        .SetProjection(Projections.Property("Publisher"))
        .Add(Restrictions.Eq("Year", 2008))
        .Add(Restrictions.Eq("Month", 4));
    session.CreateCriteria(typeof(Publisher))
        .Add(Subqueries.PropertyNotIn("Id", c))
        .List();
