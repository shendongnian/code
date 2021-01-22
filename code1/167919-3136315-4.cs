    session.CreateCriteria<A>().Add(
        Subqueries.PropertyNotIn("id",
                                 DetachedCriteria.For<A>()
                                     .CreateCriteria("MyList")
                                     .SetProjection(Projections.Property("id"))
                                     .Add(Restrictions.Ge("Date", DateTime.Today))))
