    List< Business> owner = bus.Select(m => new Business
    {
        Businessname = m.Businessname,
        Locations = m.Locations?.Select(l => new Country { /*here goes your initialization*/})
    })
    .ToList();
