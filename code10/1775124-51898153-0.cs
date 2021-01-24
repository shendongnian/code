    var query = db.CAR;
    if (!string.IsNullOrWhitespace(model.CarName))
    {
        query = query.Where(car => car.Name == model.CarName);
    }
    var items = query.Select(car => new
    {
         Car = car, // maybe better to split this up into different fields, but I don't know what the car object looks like
         // I assume your Car entity model has a navigation property to parts:
         CarPart = !string.IsNullOrWhitespace(model.CarPartName) 
                   ? car.Parts.FirstOrDefault(part => part.PartName == model.CarPartName)
                   : !string.IsNullOrWhitespace(model.CarPartCode)
                   ? car.Parts.FirstOrDefault(part => part.PartCode == model.CarPartCode)
                   : null
    })
    .ToList();
