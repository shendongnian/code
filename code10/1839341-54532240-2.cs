    var result = dbContext.CarModels
        .Where(carModel => ...)       // only if you don't want all CarModels
        .Select(carModel => new
        {
             // Select only the properties you actually plan to use!
             Id = carModel.CarModelId,
             Name = carModel.CarModelName,
             ...
             CarMakes = carModel.CarMakes
                 .Where(carMake => ...)     // only if you don't want all CarMakes of this model
                 .Select(carMake => new
                 {
                      // again: select only the properties you plan to use
                      Id = carMake.CarMakeId,
                      Name = carMake.Name,
                      ...
                 })
                 .ToList(),
        }
