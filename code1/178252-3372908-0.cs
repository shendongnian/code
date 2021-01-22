    return (int) _session.CreateCriteria<T>()
        .Add(LambdaSubquery.Property<Fund>(x => x.Id)
            .In(GetAvailableIdsPerDataUniverse(y => y.GetDataUniverseId())))
        .AddNameSearchCriteria<T>(searchExpression)
        .SetProjection(LambdaProjection.Count<T>(e => e.Id))
        .UniqueResult();
