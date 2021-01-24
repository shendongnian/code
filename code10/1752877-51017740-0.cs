    foreach (var assembly in assemblies) {
        foreach (var attributeClass in assembly.ExportedTypes) {
              if (attributeClass.CustomAttributes.Any(s => s.AttributeType.Name.Contains("RegisterScope"))) {
                  builder.RegisterType(attributeClass).AsSelf();
              }
         }
    }
