    var result = myDbContext.Vehicles
        .Where(vehicle => vehicle.CreationDate < OldDate)
        .Select(vehicle => new
        {
            LicenseNumber = vehicle.LicenseNumber,
            Owner = new
            {
                 Id = vehicle.Person.Id,
                 Name = vehicle.Person.Name,
            },
        });
