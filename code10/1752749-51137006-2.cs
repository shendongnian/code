    var result = myDbContext.Persons.Select(person => new
    {
        Id = person.Id,
        Name = person.Name,
        OldVehicles = person.Vehicles
            .Where(vehicles => vehicle.CreationDate < OldDate)
            .ToList(),
    });
