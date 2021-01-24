    query.SetProjection(Projections.ProjectionList()
        .Add(Projections.Property("rootAlias.ID"))
        .Add(Projections.Property("rootAlias.OtherId"))
        .Add(Projections.Property("otherAlias.ID"))
        .Add(Projections.Property("otherAlias.PropertyName"))
    );
