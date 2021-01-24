    ForAllMaps((typeMap, mappingExpression) =>
    {
        if (typeMap.DestinationType.GetProperty($"{typeMap.SourceType.Name}Id") != null)
        {
            mappingExpression.ForMember($"{typeMap.SourceType.Name}Id", o => o.MapFrom("Id"));
        }
    });
