    // We get the assembly through the base class
    var baseAssembly = typeof(baseClass).GetTypeInfo().Assembly;
    
    // we filter the defined classes according to the interfaces they implement
    var typeList = baseAssembly.DefinedTypes.Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(IMyInterface))).ToList();
