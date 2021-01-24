    ...
    foreach (var property in properties) 
    {
        var info = context.SemanticModel.GetTypeInfo(property);
        var typeSymbol = info.Type ?? info.ConvertedType; 
        ...
    }
