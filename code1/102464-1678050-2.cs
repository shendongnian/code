    var max = (int)session.CreateCriteria<Game>("game")
        .SetProjection(Projections.ProjectionList()
                           .Add(Projections.GroupProperty("game.Match"))
                           .Add(Projections.Sum("game.Score"), "total"))
        .AddOrder(Order.Desc("total"))
        .SetMaxResults(1)
        .SetResultTransformer(Transformers.AliasToEntityMap)
        .UniqueResult<IDictionary>()["total"];
