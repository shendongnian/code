    foreach (var type in assembly.GetTypes().Where(t => typeof(BaseModel).IsAssignableFrom(t) && t.Name != nameof(ProblematicType) && !t.IsAbstract))
    {
        var mappingName = string.Join(".", type.Namespace.Replace("Model", "DataMapping"), type.Name) + ".hbm.xml";
        configuration.AddResource(mappingName, assembly);
    }
