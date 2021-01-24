    List<Colour> selectedColours = GetSelectedColours(); // colours from cache
    Family selectedFamily = GetSelectedFamily(); // family from cache
    
    var plant = new Plant
    {
        Name = "Black alder",
        FamilyId = selectedFamily.Id // Family property is null
    };
    
    plant.PlantColours = selectedColours.Select(c => new PlantColour
    {
        Plant = plant,
        ColourId = c.Id // Colour property is null
    }).ToList();
    myDbContext.Set<Plant>.Add(plant);
    await myDbContext.SaveChangesAsync();
