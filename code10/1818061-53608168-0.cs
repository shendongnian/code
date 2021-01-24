    var query = (
        from SLD in Context.ShipmentLocations
        where ... // you could add some filters here
        select SLD
    );
    if(ishHub == true)
    {
        query = (
            from SLD in query 
            join CMD in context.CityMasters on SLD.City equals CMD.ID
            select CMD
        )
    } 
    else {
        query = (
            from SLD in query 
            join CMD in context.CountryMasters on SLD.Country equals CMD.ID
            select CMD
        )
    }
    query = (
        from CMD in query
        select new ControlTowerCity
        { 
            Name = CMD.Name,
        }
    );
    var result = query.ToList();
