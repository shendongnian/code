    ICriteria demoCriteria = session.CreateCriteria<Demo>();
    ...
    demoCriteria.Add(Restrictions...);
    ...
    ICriteria tagCriteria = demoCriteria.CreateCriteria("Tags");
    tagCriteria.Add(Restrictions.In("elements", new {"Tag1", "Tag2", ...}));
    return demoCriteria.List<Demo>();
