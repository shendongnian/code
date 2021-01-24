    var result = currentContext.SystemAreas.Select(systemArea => new
    {
         Id = systemArea.Id,
         Code = systemArea.Code,
         ...
         // if you want a collection of SystemAreaFunctionalities
         // where every SystemAreaFunctionality is filled with only SysemAreaCode
         // do the following:
         SystemAreaFunctionalities = systemArea.SystemAreaFunctionalities
              .Select(systemAreaFunctionality => new SystemAreFunctionality
              {
                   SystemAreaCode = systemAreaFunctionality.SystemAreaCode,
              })
              .ToList(),   // DON'T FORGET THIS, OR YOU WON'T GET RESULTS!
        })
        .ToList()
    }
