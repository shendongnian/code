    ...
    SystemAreaFunctionalities = systemArea.SystemAreaFunctionalities
        .Select(systemAreaFunctionality => new
        {
            // again: select only the properties you plan to use!
            Id = systemAreaFunctionality.Id
            SystemAreaCode = systemAreaFunctionality.SystemAreaCode,
         })
