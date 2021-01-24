    var result = currentContext.SystemAreas.Select(systemArea => new
    {
         // select only the properties you actually plan to use
         Id = systemArea.Id,
         Code = systemArea.Code,
         ...
         // if you only need the SystemAreaCodes, select only that property
         SystemAreaCodes = systemArea.SystemAreaFunctionalities
              .Select(systemAreaFunctionality => systemAreaFunctionality.SystemAreaCode)
              .ToList(),
        })
        .ToList()
    };
