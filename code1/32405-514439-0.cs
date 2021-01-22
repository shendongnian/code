    // If a filter on the pet name is required, filter.
    if (!string.IsNullOrEmpty(petNameFilter))
    {
       // Filter on pet name.
       users = users.Where(u => u.Pets.Where(
         p => p.Name == petNameFilter).Any());
    }
    
    // Add a filter on the license plate number.
    if (!string.IsNullOrEmpty(licensePlateFilter))
    {
      // Filter on the license plate.
      users = users.Where(
        u => u.Cars.Where(c => c.LicensePlace == licensePlateFilter).Any());
    }
