    var aggregateCatalog = new AggregateCatalog(...);
    var assemblies = aggregateCatalog.Parts
        .Select(part => ReflectionModelServices.GetPartType(part).Value.Assembly)
        .Distinct()
        .ToList();
    
