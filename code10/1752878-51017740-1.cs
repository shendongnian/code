    foreach (var assembly in assemblies) {
        builder
            .RegisterAssemblyTypes(assembly)
            .Where(t => t.CustomAttributes.Any(s => s.AttributeType.Name.Contains("RegisterScope")))
            .AsSelf();
    }
