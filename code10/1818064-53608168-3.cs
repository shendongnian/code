    var query = (
        from SLD in Context.ShipmentLocations
        where ... // you could add some filters here
        select SLD
    );
    IQueryable<ControlTowerCity> query2;
    if(ishHub == true)
    {
        query2 = (
            from SLD in query 
            join CMD in context.CityMasters on SLD.City equals CMD.ID
            select CMD
        )
    } 
    else {
        query2 = (
            from SLD in query 
            join CMD in context.CountryMasters on SLD.Country equals CMD.ID
            select CMD
        )
    }
    var result = (
        from CMD in query2
        select new ControlTowerCity
        { 
            Name = CMD.Name,
        }
    ).ToList();
