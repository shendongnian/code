    IProjection howMany = Projections.Count("Id").As("HowMany");
    
    ICriteria criteria = session
        .CreateCriteria<L10N>()
        .SetProjection(
            howMany,
            Projections.GroupProperty("Native"),
            Projections.GroupProperty("Locale")
        );
    
    criteria.Add(Restrictions.Gt(howMany,1));
