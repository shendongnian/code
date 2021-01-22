    var result = _session.CreateCriteria<Company>()
        .Add(Restrictions.In(groupCompanyInfo, (int[])groups.Select(xx => xx.Id).ToArray()))
        .SetProjection(Projections.ProjectionList()
            .Add(Projections.GroupProperty(groupCompanyInfo))
            .Add(Projections.RowCount())) // note, I removed the aliases
        .List();
