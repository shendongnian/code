    protected DetachedCriteria GetAvailableIdsPerDataUniverse(Expression<Fund, int> e)
    {
        return DetachedCriteria.For<Fund>()
            .SetFetchMode<Fund>(f => f.ShareClasses, FetchMode.Join)
            .CreateCriteria<Fund>(f => f.ShareClasses)
            .Add(LambdaSubquery.Property<ShareClass>(x => x.Id).In(GetAvailableShareClassIdsPerDataUniverse()))
            .Add<ShareClass>(f => f.ExcludeFromFT == false).
            .SetProjection(LambdaProjection.Property<Fund>(e));
    }
    GetAvailableIdsPerDataUniverse(e => e.Category.Id)
    //...
