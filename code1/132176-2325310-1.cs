    public override IQueryable<ApplicationVehicleSummary> GetQuery(ISession session)
        {
            var results = session.Linq<Vehicle>()
                .Select(v => new ApplicationVehicleSummary
                                 {
                                     Make = v.Make,
                                     Model = v.Model,
                                     Type = v.Type,
                                     Engine = v.Engine,
                                     IsLinked = v.Applications.Any(a => a.Name == _name)
                                 })
                .Where(v =>
                       v.Make == _criteria.Make &&
                       v.Model == _criteria.Model &&
                       v.Type == _criteria.Type &&
                       v.Engine == _criteria.Engine
                );
            return results;
        }
