    using (var context = new LadingControlTowerEntities()) {
        var query = context.ShipmentLocations .AsQueryable();
        IQueryable<ControlTowerCity> resultQuery;
        if (ishHub)
            resultQuery = query.Join(context.CityMasters, t => t.City, t => t.ID, (o, i) => new ControlTowerCity { Name = CMD.Name });
        else
            resultQuery = query.Join(context.CountryMasters, t => t.Country, t => t.ID, (o, i) => new ControlTowerCity { Name = CMD.Name });
        var mapcityDetail = resultQuery.ToList();
        return mapcityDetail;
    }
