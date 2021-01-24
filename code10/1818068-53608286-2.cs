    using (var context = new LadingControlTowerEntities()) {
        var query = context.ShipmentLocations.AsQueryable();
        // if you have any condition (for example, what you said in comment):
        query = query.Where(t => t.Status == "A");
        IQueryable<ControlTowerCity> resultQuery;
        if (ishHub)
            resultQuery = query.Join(context.CityMasters, t => t.City, t => t.ID, (o, i) => new ControlTowerCity { Name = i.Name });
        else
            resultQuery = query.Join(context.CountryMasters, t => t.Country, t => t.ID, (o, i) => new ControlTowerCity { Name = i.Name });
        var mapcityDetail = resultQuery.ToList();
        return mapcityDetail;
    }
