    var or = new Disjunction();
    foreach(var id in idCollection)
        or.Add(Expression.Eq("MyFeatureValue.Id", id);
    var query = DetachedCriteria.For<Estate>();
    query
        .CreateCriteria("EstateFeatures")
        .Add(and);
    var estates = query.GetExecutableCriteria(session).List<Estate>();
