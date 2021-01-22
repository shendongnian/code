    public override IQueryable<ApplicationVehicleSummary> GetQuery(ISession session)
    {
            ICriteria criteria = session.CreateCriteria<Vehicle>();
            // SELECT
            criteria
                .SetProjection(
                Projections.Property("Make"),
                Projections.Property("Model"),
                Projections.Property("Type"),
                Projections.Property("Engine")
                );
            // WHERE
            criteria
                .Add(
                Restrictions.Eq("Make", _criteria.Make) &&
                Restrictions.Eq("Model", _criteria.Model) &&
                Restrictions.Eq("Type", _criteria.Type) &&
                Restrictions.Eq("Engine", _criteria.Engine)
                );
            //criteria.Add(Something("IsLinked",Subqueries.Gt(0,subCriteria)));
            criteria.SetResultTransformer(Transformers.AliasToBean<ApplicationVehicleSummary>());
            return criteria.List<ApplicationVehicleSummary>().AsQueryable();
    }
